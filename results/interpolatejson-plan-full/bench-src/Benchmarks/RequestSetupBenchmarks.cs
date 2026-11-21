using System.Net;
using System.Net.Http;
using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Credentials;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Tracing;
using Amazon.Util.Internal;
using BenchmarkDotNet.Attributes;
using ExecutionContext = Amazon.Runtime.Internal.ExecutionContext;

namespace CoreBenchmarks.Benchmarks;

// Request setup microbenchmarks: the per-request work done before signing and sending.
// Each benchmark builds a fresh RequestContext, as the SDK does for every call, and runs one
// pipeline step on it: the Marshaller handler (user-agent components and feature ids), the auth
// resolver handler (auth scheme selection and identity resolution), or the default credential
// chain's cached lookup.
// Only APIs that exist on the base commit are used (ab.sh runs this source against both sides).
[MemoryDiagnoser]
public class RequestSetupBenchmarks
{
    private const string AccessKey = "AKIDEXAMPLE";
    private const string SecretKey = "wJalrXUtnFEMI/K7MDENG+bPxRfiCYEXAMPLEKEY";

    private BenchClientConfig _explicitCredsConfig;
    private BenchClientConfig _defaultChainConfig;
    private StubRequest _originalRequest;
    private StubMarshaller _marshaller;
    private BenchAuthResolver _authResolver;
    private DefaultAWSCredentialsIdentityResolver _defaultResolver;
    private TelemetryPipelineClient _telemetryClient;
    private TelemetryPipelineRequest _telemetryRequest;

    [GlobalSetup]
    public void Setup()
    {
        // The default credential chain resolves from environment variables and then serves its cached
        // credentials, re-checking the environment on every call.
        Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", AccessKey);
        Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", SecretKey);

        _explicitCredsConfig = new BenchClientConfig
        {
            DefaultAWSCredentials = new BasicAWSCredentials(AccessKey, SecretKey),
        };
        _defaultChainConfig = new BenchClientConfig();
        _originalRequest = new StubRequest();
        _marshaller = new StubMarshaller();
        _authResolver = new BenchAuthResolver();
        _defaultResolver = new DefaultAWSCredentialsIdentityResolver();

        // Prime the caches so every measured call takes the steady-state path.
        _defaultResolver.ResolveIdentity(_defaultChainConfig);
        Marshaller_PreInvoke();
        AuthResolver_PreInvoke_DefaultChain();

        _telemetryClient = TelemetryPipelineClient.Create();
        _telemetryRequest = new TelemetryPipelineRequest();
        Telemetry_InvokeSync();
        Telemetry_InvokeAsync().GetAwaiter().GetResult();
    }

    [GlobalCleanup]
    public void Cleanup() => _telemetryClient?.Dispose();

    [Benchmark]
    public UserAgentDetails Marshaller_PreInvoke()
    {
        var context = NewContext(_explicitCredsConfig, isAsync: true);
        BenchMarshaller.Run(context);
        return context.RequestContext.UserAgentDetails;
    }

    [Benchmark]
    public BaseIdentity AuthResolver_PreInvoke_ExplicitCredentials()
    {
        var context = NewMarshalledContext(_explicitCredsConfig, isAsync: false);
        _authResolver.Run(context);
        return context.RequestContext.Identity;
    }

    [Benchmark]
    public async Task<BaseIdentity> AuthResolver_PreInvokeAsync_ExplicitCredentials()
    {
        var context = NewMarshalledContext(_explicitCredsConfig, isAsync: true);
        await _authResolver.RunAsync(context).ConfigureAwait(false);
        return context.RequestContext.Identity;
    }

    [Benchmark]
    public BaseIdentity AuthResolver_PreInvoke_DefaultChain()
    {
        var context = NewMarshalledContext(_defaultChainConfig, isAsync: false);
        _authResolver.Run(context);
        return context.RequestContext.Identity;
    }

    [Benchmark]
    public async Task<BaseIdentity> AuthResolver_PreInvokeAsync_DefaultChain()
    {
        var context = NewMarshalledContext(_defaultChainConfig, isAsync: true);
        await _authResolver.RunAsync(context).ConfigureAwait(false);
        return context.RequestContext.Identity;
    }

    [Benchmark]
    public AWSCredentials DefaultChain_ResolveIdentity()
        => _defaultResolver.ResolveIdentity(_defaultChainConfig);

    [Benchmark]
    public Task<BaseIdentity> DefaultChain_ResolveIdentityAsync()
        => ((IIdentityResolver)_defaultResolver).ResolveIdentityAsync(_defaultChainConfig);

    [Benchmark]
    public UserAgentDetails UserAgentDetails_Build()
    {
        // The components and feature ids a typical request adds before the User-Agent header is set.
        var details = new UserAgentDetails();
        details.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_RES_WHEN_SUPPORTED);
        details.AddFeature(UserAgentFeatureId.ACCOUNT_ID_MODE_PREFERRED);
        details.AddUserAgentComponent(BenchClientConfig.UserAgentString);
        details.AddUserAgentComponent("md/ClientAsync");
        details.AddUserAgentComponent("cfg/init-coll#0");
        details.AddFeature(UserAgentFeatureId.FLEXIBLE_CHECKSUMS_REQ_WHEN_SUPPORTED);
        details.AddFeature(UserAgentFeatureId.CREDENTIALS_CODE);
        return details;
    }

    // A whole pipeline call with a telemetry provider whose meters and tracers do nothing, so the
    // measured cost is what the SDK itself spends on metric and span bookkeeping per request
    // (scopes, operation names, attributes) on top of the default pipeline.
    [Benchmark]
    public string Telemetry_InvokeSync()
        => _telemetryClient.Call(_telemetryRequest).ResponseMetadata.RequestId;

    [Benchmark]
    public async Task<string> Telemetry_InvokeAsync()
        => (await _telemetryClient.CallAsync(_telemetryRequest).ConfigureAwait(false)).ResponseMetadata.RequestId;

    private ExecutionContext NewContext(BenchClientConfig config, bool isAsync)
    {
        var requestContext = new RequestContext(false)
        {
            ClientConfig = config,
            OriginalRequest = _originalRequest,
            Marshaller = _marshaller,
            IsAsync = isAsync,
        };
        return new ExecutionContext(requestContext, new ResponseContext());
    }

    private ExecutionContext NewMarshalledContext(BenchClientConfig config, bool isAsync)
    {
        var context = NewContext(config, isAsync);
        context.RequestContext.Request = _marshaller.Marshall(_originalRequest);
        return context;
    }

    private sealed class StubRequest : AmazonWebServiceRequest { }

    private sealed class StubMarshaller : IMarshaller<IRequest, AmazonWebServiceRequest>
    {
        private static readonly byte[] Body = Encoding.UTF8.GetBytes(
            "{\"TableName\":\"my-table\",\"Key\":{\"pk\":{\"S\":\"user#12345\"},\"sk\":{\"S\":\"profile\"}},\"ConsistentRead\":true}");

        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            var request = new DefaultRequest(input, "AmazonDynamoDBv2")
            {
                HttpMethod = "POST",
                ResourcePath = "/",
                Content = Body,
            };
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.Headers["X-Amz-Target"] = "DynamoDB_20120810.GetItem";
            return request;
        }
    }

    private sealed class BenchMarshaller : Marshaller
    {
        public static void Run(IExecutionContext context) => PreInvoke(context);
    }

    private sealed class BenchAuthResolver : BaseAuthResolverHandler
    {
        public void Run(IExecutionContext context) => PreInvoke(context);
        public Task RunAsync(IExecutionContext context) => PreInvokeAsync(context);

        protected override List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext)
            => AuthSchemeOption.DEFAULT_SIGV4;
    }

    private sealed class BenchClientConfig : ClientConfig
    {
        // A User-Agent of the same shape and length as a generated service client's.
        public static readonly string UserAgentString = InternalSDKUtils.BuildUserAgentString("DynamoDB", "4.0.0.0");

        public BenchClientConfig() : base(new Provider()) { }

        public override string RegionEndpointServiceName => "dynamodb";
        public override string ServiceVersion => "2012-08-10";
        public override string UserAgent => UserAgentString;

        public override Amazon.Runtime.Endpoints.Endpoint DetermineServiceOperationEndpoint(Amazon.Runtime.Endpoints.ServiceOperationEndpointParameters parameters)
            => new Amazon.Runtime.Endpoints.Endpoint("https://dynamodb.us-west-2.amazonaws.com");

        private sealed class Provider : IDefaultConfigurationProvider
        {
            public IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null)
                => new DefaultConfiguration();
        }
    }
    public sealed class TelemetryPipelineRequest : AmazonWebServiceRequest { }

    public sealed class TelemetryPipelineResponse : AmazonWebServiceResponse { }

    private sealed class TelemetryPipelineClient : AmazonServiceClient
    {
        private TelemetryPipelineClient(AWSCredentials credentials, ClientConfig config) : base(credentials, config) { }

        public static TelemetryPipelineClient Create()
        {
            var config = new TelemetryPipelineConfig
            {
                RegionEndpoint = RegionEndpoint.USWest2,
                AuthenticationServiceName = "dynamodb",
                ServiceId = "DynamoDB",
                HttpClientFactory = new FakeHttpClientFactory(),
                TelemetryProvider = new NullListenerTelemetryProvider(),
            };
            return new TelemetryPipelineClient(new BasicAWSCredentials(AccessKey, SecretKey), config);
        }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
            => pipeline.AddHandlerAfter<Marshaller>(new TelemetryAuthSchemeHandler());

        private static InvokeOptions Options() => new InvokeOptions
        {
            RequestMarshaller = TelemetryRequestMarshaller.Instance,
            ResponseUnmarshaller = TelemetryResponseUnmarshaller.Instance,
        };

        public TelemetryPipelineResponse Call(TelemetryPipelineRequest request)
            => Invoke<TelemetryPipelineResponse>(request, Options());

        public Task<TelemetryPipelineResponse> CallAsync(TelemetryPipelineRequest request)
            => InvokeAsync<TelemetryPipelineResponse>(request, Options(), default);
    }

    private sealed class TelemetryAuthSchemeHandler : BaseAuthResolverHandler
    {
        protected override List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext)
            => AuthSchemeOption.DEFAULT_SIGV4;
    }

    private sealed class TelemetryRequestMarshaller : IMarshaller<IRequest, AmazonWebServiceRequest>
    {
        public static readonly TelemetryRequestMarshaller Instance = new();

        private static readonly byte[] Body = Encoding.UTF8.GetBytes("{\"TableName\":\"my-table\"}");

        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            IRequest request = new DefaultRequest(input, "AmazonDynamoDBv2");
            request.Headers["X-Amz-Target"] = "DynamoDB_20120810.DescribeTable";
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";
            request.ResourcePath = "/";
            request.Content = Body;
            return request;
        }
    }

    private sealed class TelemetryResponseUnmarshaller : JsonResponseUnmarshaller
    {
        public static readonly TelemetryResponseUnmarshaller Instance = new();

        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
            var reader = new StreamingUtf8JsonReader(context.Stream, AWSConfigs.StreamingUtf8JsonReaderBufferSize ?? 4096, context.JsonMaxDepth);
            context.Read(ref reader);
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth, ref reader)) { }
            return new TelemetryPipelineResponse();
        }

        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
            => new AmazonServiceException("error", innerException, ErrorType.Unknown, "Error", null, statusCode);
    }

    private sealed class FakeHttpClientFactory : HttpClientFactory
    {
        public override HttpClient CreateHttpClient(IClientConfig clientConfig) => new HttpClient(new FakeHttpMessageHandler());
    }

    private sealed class FakeHttpMessageHandler : HttpMessageHandler
    {
        private static readonly byte[] ResponseBody = Encoding.UTF8.GetBytes("{\"Table\":{}}");

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            => CreateResponse(request);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(CreateResponse(request));

        private static HttpResponseMessage CreateResponse(HttpRequestMessage request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request,
                Content = new ByteArrayContent(ResponseBody),
            };
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/x-amz-json-1.0");
            response.Headers.TryAddWithoutValidation("x-amzn-RequestId", "4KHM2B6DFM8QOVQ1TQ6BJPO5O3VV4KQNSO5AEMVJF66Q9ASUAAJG");
            response.Headers.Date = DateTimeOffset.UtcNow;
            return response;
        }
    }

    private sealed class TelemetryPipelineConfig : ClientConfig
    {
        public TelemetryPipelineConfig() : base(new Provider()) { }

        public override string RegionEndpointServiceName => "dynamodb";
        public override string ServiceVersion => "2012-08-10";
        public override string UserAgent => BenchClientConfig.UserAgentString;

        public override Amazon.Runtime.Endpoints.Endpoint DetermineServiceOperationEndpoint(Amazon.Runtime.Endpoints.ServiceOperationEndpointParameters parameters)
            => new Amazon.Runtime.Endpoints.Endpoint("https://dynamodb.us-west-2.amazonaws.com");

        private sealed class Provider : IDefaultConfigurationProvider
        {
            public IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null)
                => new DefaultConfiguration();
        }
    }

    // Telemetry providers that are not the SDK's internal no-op types, so the SDK takes its
    // "telemetry enabled" paths, but whose instruments discard everything they receive.
    private sealed class NullListenerTelemetryProvider : TelemetryProvider
    {
        public NullListenerTelemetryProvider() : base(new NullMeterProvider(), new NullTracerProvider()) { }
    }

    private sealed class NullMeterProvider : MeterProvider
    {
        private static readonly NullMeter Meter = new();
        public override Amazon.Runtime.Telemetry.Metrics.Meter GetMeter(string scope, Attributes attributes = null) => Meter;
    }

    private sealed class NullMeter : Amazon.Runtime.Telemetry.Metrics.Meter
    {
        public override UpDownCounter<T> CreateUpDownCounter<T>(string name, string units = null, string description = null)
            => NullUpDownCounter<T>.Instance;
        public override MonotonicCounter<T> CreateMonotonicCounter<T>(string name, string units = null, string description = null)
            => NullMonotonicCounter<T>.Instance;
        public override Histogram<T> CreateHistogram<T>(string name, string units = null, string description = null)
            => NullHistogram<T>.Instance;
    }

    private sealed class NullUpDownCounter<T> : UpDownCounter<T> where T : struct
    {
        public static readonly NullUpDownCounter<T> Instance = new();
        public override void Add(T value, Attributes attributes = null) { }
    }

    private sealed class NullMonotonicCounter<T> : MonotonicCounter<T> where T : struct
    {
        public static readonly NullMonotonicCounter<T> Instance = new();
        public override void Add(T value, Attributes attributes = null) { }
    }

    private sealed class NullHistogram<T> : Histogram<T> where T : struct
    {
        public static readonly NullHistogram<T> Instance = new();
        public override void Record(T value, Attributes attributes = null) { }
    }

    private sealed class NullTracerProvider : TracerProvider
    {
        private static readonly NullTracer Tracer = new();
        public override Amazon.Runtime.Telemetry.Tracing.Tracer GetTracer(string scope) => Tracer;
    }

    private sealed class NullTracer : Amazon.Runtime.Telemetry.Tracing.Tracer
    {
        public override TraceSpan CreateSpan(string name, Attributes initialAttributes = null, SpanKind spanKind = SpanKind.INTERNAL, SpanContext parentContext = null)
            => new NullSpan();
    }

    private sealed class NullSpan : TraceSpan
    {
        public override void EmitEvent(string name, Attributes attributes = null) { }
        public override void SetAttribute(string key, object value) { }
        public override void SetStatus(SpanStatus status) { }
        public override void RecordException(Exception exception, Attributes attributes = null) { }
        public override void End() { }
    }
}
