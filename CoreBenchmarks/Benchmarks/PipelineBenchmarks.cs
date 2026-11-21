using System.Net;
using System.Net.Http;
using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using BenchmarkDotNet.Attributes;

namespace CoreBenchmarks.Benchmarks;

// End-to-end runtime pipeline microbenchmarks. A minimal service client built on AmazonServiceClient
// sends a DynamoDB-shaped JSON POST through the SDK's default handler chain (Metrics, ErrorCallback,
// callbacks, Marshaller, auth scheme resolver, EndpointResolver, Compression, Retry, Checksum,
// EndpointDiscovery, Signer, ErrorHandler, Unmarshaller, HttpHandler). The real HttpRequestMessageFactory
// is used; only the HttpMessageHandler under HttpClient is replaced with an in-memory fake, so no
// network is involved. The marshaller writes a fixed body and the unmarshaller reads a small JSON
// response, so the measured work is dominated by the pipeline itself (plus SigV4 signing).
// Only APIs that exist on the base commit are used (ab.sh runs this source against both sides).
[MemoryDiagnoser]
public class PipelineBenchmarks
{
    private BenchPipelineClient _client;
    private BenchPipelineClient _yieldingClient;
    private BenchPipelineClient _errorClient;
    private BenchPipelineClient _yieldingErrorClient;
    private BenchPipelineClient _manyHeadersClient;
    private BenchPipelineClient _yieldingManyHeadersClient;
    private BenchPipelineClient _rulesClient;
    private BenchPipelineClient _yieldingRulesClient;
    private BenchPipelineClient _discoveryClient;
    private BenchPipelineClient _yieldingDiscoveryClient;
    private BenchPipelineRequest _request;
    private DefaultRequest _restLabelRequest;
    private DefaultRequest _s3KeyRequest;
    private Amazon.Runtime.Endpoints.Endpoint _s3Endpoint;
    private Amazon.Runtime.Endpoints.Endpoint _multiSchemeEndpoint;

    [GlobalSetup]
    public void Setup()
    {
        _client = CreateClient(yieldInHandler: false);
        _yieldingClient = CreateClient(yieldInHandler: true);
        _errorClient = CreateClient(yieldInHandler: false, error: true);
        _yieldingErrorClient = CreateClient(yieldInHandler: true, error: true);
        _manyHeadersClient = CreateClient(yieldInHandler: false, manyHeaders: true);
        _yieldingManyHeadersClient = CreateClient(yieldInHandler: true, manyHeaders: true);
        _rulesClient = CreateClient(yieldInHandler: false, endpointRules: true);
        _yieldingRulesClient = CreateClient(yieldInHandler: true, endpointRules: true);
        _discoveryClient = CreateClient(yieldInHandler: false, endpointDiscovery: true);
        _yieldingDiscoveryClient = CreateClient(yieldInHandler: true, endpointDiscovery: true);
        _request = new BenchPipelineRequest();

        // REST requests as the generated marshallers build them: a Lambda Invoke-shaped path with one label,
        // and an S3 GetObject-shaped greedy key (virtual-host bucket, so the path is just the key).
        _restLabelRequest = new DefaultRequest(new BenchPipelineRequest(), "AWSLambda")
        {
            Endpoint = new Uri("https://lambda.us-west-2.amazonaws.com"),
            ResourcePath = "/2015-03-31/functions/{FunctionName}/invocations",
            HttpMethod = "POST",
        };
        _restLabelRequest.AddPathResource("{FunctionName}", "my-function");
        _s3KeyRequest = new DefaultRequest(new BenchPipelineRequest(), "AmazonS3")
        {
            Endpoint = new Uri("https://amzn-s3-demo-bucket.s3.us-west-2.amazonaws.com"),
            ResourcePath = "/{Key+}",
            HttpMethod = "GET",
        };
        _s3KeyRequest.AddPathResource("{Key+}", "photos/2024/summer/beach day.jpg");

        // Resolved endpoints carrying authSchemes, as the S3 rules return them (one SigV4 scheme) and as a
        // multi-Region access point or EventBridge global endpoint returns them (SigV4a, then SigV4).
        _s3Endpoint = new Amazon.Runtime.Endpoints.Endpoint("https://amzn-s3-demo-bucket.s3.us-west-2.amazonaws.com",
            "{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-west-2\"}]}", null);
        _multiSchemeEndpoint = new Amazon.Runtime.Endpoints.Endpoint("https://mfzwi23gnjvgw.mrap.accesspoint.s3-global.amazonaws.com",
            "{\"authSchemes\":[{\"disableDoubleEncoding\":true,\"name\":\"sigv4a\",\"signingName\":\"s3\",\"signingRegionSet\":[\"*\"]},{\"disableDoubleEncoding\":true,\"name\":\"sigv4\",\"signingName\":\"s3\",\"signingRegion\":\"us-east-1\"}]}", null);

        // Warm up connection caches, user-agent caches and similar one-time state.
        _client.Call(_request);
        _client.CallAsync(_request).GetAwaiter().GetResult();
        _yieldingClient.CallAsync(_request).GetAwaiter().GetResult();
        InvokeSync_ServiceError();
        InvokeAsync_ServiceError_Yielding().GetAwaiter().GetResult();
        InvokeSync_JsonPost_ManyResponseHeaders();
        InvokeAsync_JsonPost_ManyResponseHeaders_Yielding().GetAwaiter().GetResult();
        EndpointRules_InvokeSync_JsonPost();
        EndpointRules_InvokeAsync_JsonPost_Yielding().GetAwaiter().GetResult();
        EndpointDiscovery_InvokeSync_JsonPost();
        EndpointDiscovery_InvokeAsync_JsonPost_Yielding().GetAwaiter().GetResult();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _client?.Dispose();
        _yieldingClient?.Dispose();
        _errorClient?.Dispose();
        _yieldingErrorClient?.Dispose();
        _manyHeadersClient?.Dispose();
        _yieldingManyHeadersClient?.Dispose();
        _rulesClient?.Dispose();
        _yieldingRulesClient?.Dispose();
        _discoveryClient?.Dispose();
        _yieldingDiscoveryClient?.Dispose();
    }

    private static BenchPipelineClient CreateClient(bool yieldInHandler, bool error = false, bool manyHeaders = false, bool endpointRules = false, bool endpointDiscovery = false)
    {
        var config = new BenchPipelineConfig
        {
            RegionEndpoint = RegionEndpoint.USWest2,
            AuthenticationServiceName = "dynamodb",
            HttpClientFactory = new FakeHttpClientFactory(yieldInHandler, error, manyHeaders),
        };
        if (endpointRules)
            config.EndpointProvider = BenchEndpointProvider.Instance;
        return new BenchPipelineClient(new BasicAWSCredentials("AKIDEXAMPLE", "wJalrXUtnFEMI/K7MDENG+bPxRfiCYEXAMPLEKEY"), config, endpointRules, endpointDiscovery);
    }

    // Synchronous Invoke through the whole pipeline.
    [Benchmark]
    public string InvokeSync_JsonPost()
    {
        return _client.Call(_request).ResponseMetadata.RequestId;
    }

    // InvokeAsync where the fake HTTP handler completes synchronously.
    [Benchmark]
    public string InvokeAsync_JsonPost()
    {
        return _client.CallAsync(_request).GetAwaiter().GetResult().ResponseMetadata.RequestId;
    }

    // InvokeAsync where the fake HTTP handler yields, so every async handler in the chain suspends
    // and resumes as it does with a real network call.
    [Benchmark]
    public async Task<string> InvokeAsync_JsonPost_Yielding()
    {
        var response = await _yieldingClient.CallAsync(_request).ConfigureAwait(false);
        return response.ResponseMetadata.RequestId;
    }

    // Success responses carrying the dozen headers an S3 object response typically has (request ids,
    // Date, Last-Modified, ETag, encryption and version headers, Accept-Ranges, Server), instead of four.
    [Benchmark]
    public string InvokeSync_JsonPost_ManyResponseHeaders()
    {
        return _manyHeadersClient.Call(_request).ResponseMetadata.RequestId;
    }

    [Benchmark]
    public async Task<string> InvokeAsync_JsonPost_ManyResponseHeaders_Yielding()
    {
        var response = await _yieldingManyHeadersClient.CallAsync(_request).ConfigureAwait(false);
        return response.ResponseMetadata.RequestId;
    }

    // A non-retryable 400 service error (for example a failed condition check), through the whole
    // pipeline: error unmarshalling, the retry decision and the exception path of every handler.
    [Benchmark]
    public string InvokeSync_ServiceError()
    {
        try
        {
            _errorClient.Call(_request);
            return null;
        }
        catch (AmazonServiceException e)
        {
            return e.ErrorCode;
        }
    }

    [Benchmark]
    public async Task<string> InvokeAsync_ServiceError_Yielding()
    {
        try
        {
            await _yieldingErrorClient.CallAsync(_request).ConfigureAwait(false);
            return null;
        }
        catch (AmazonServiceException e)
        {
            return e.ErrorCode;
        }
    }

    // The same JSON POST through a client wired the way generated clients are: the legacy EndpointResolver is
    // removed and a BaseEndpointResolver subclass resolves the endpoint from the client's EndpointProvider on
    // every request. The provider builds a new URL string per call, as the generated rule providers do, but skips
    // rule evaluation, so the rows measure what the pipeline does with the resolved endpoint.
    [Benchmark]
    public string EndpointRules_InvokeSync_JsonPost()
    {
        return _rulesClient.Call(_request).ResponseMetadata.RequestId;
    }

    [Benchmark]
    public async Task<string> EndpointRules_InvokeAsync_JsonPost_Yielding()
    {
        var response = await _yieldingRulesClient.CallAsync(_request).ConfigureAwait(false);
        return response.ResponseMetadata.RequestId;
    }

    // The same JSON POST for an operation that requires endpoint discovery (as Amazon Timestream Write and Query
    // operations do): the generated client sets EndpointDiscoveryMarshaller and EndpointOperation on the invoke
    // options, and EndpointDiscoveryHandler resolves the discovered endpoint from the client's cache on every request.
    // The discovery call itself is made once, during setup.
    [Benchmark]
    public string EndpointDiscovery_InvokeSync_JsonPost()
    {
        return _discoveryClient.Call(_request).ResponseMetadata.RequestId;
    }

    [Benchmark]
    public async Task<string> EndpointDiscovery_InvokeAsync_JsonPost_Yielding()
    {
        var response = await _yieldingDiscoveryClient.CallAsync(_request).ConfigureAwait(false);
        return response.ResponseMetadata.RequestId;
    }

    // URL composition for REST requests (HttpHandler calls this once per attempt): resolving path labels
    // into the resource path, then building the request Uri.
    [Benchmark]
    public string RestUrl_ResolvePath_Label()
        => AWSSDKUtils.ResolveResourcePathV2("2015-03-31/functions/{FunctionName}/invocations", _restLabelRequest.PathResources);

    [Benchmark]
    public string RestUrl_ResolvePath_S3GreedyKey()
        => AWSSDKUtils.ResolveResourcePathV2("{Key+}", _s3KeyRequest.PathResources);

    [Benchmark]
    public Uri RestUrl_ComposeUrl_Label() => AmazonServiceClient.ComposeUrl(_restLabelRequest);

    [Benchmark]
    public Uri RestUrl_ComposeUrl_S3GreedyKey() => AmazonServiceClient.ComposeUrl(_s3KeyRequest);

    // The auth scheme resolvers of services whose endpoint rules carry auth schemes (S3, EventBridge, SESv2,
    // CloudFront KeyValueStore) read them from the resolved endpoint on every request.
    [Benchmark]
    public int EndpointAuthSchemes_SingleSigV4() => BenchAuthSchemeHandler.FromEndpoint(_s3Endpoint).Count;

    [Benchmark]
    public int EndpointAuthSchemes_SigV4aAndSigV4() => BenchAuthSchemeHandler.FromEndpoint(_multiSchemeEndpoint).Count;

    public sealed class BenchPipelineRequest : AmazonWebServiceRequest { }

    public sealed class BenchPipelineResponse : AmazonWebServiceResponse
    {
        public long? ReadCapacity { get; set; }
        public long? WriteCapacity { get; set; }
    }

    private sealed class BenchPipelineClient : AmazonServiceClient
    {
        private readonly bool _endpointDiscovery;

        public BenchPipelineClient(AWSCredentials credentials, ClientConfig config) : this(credentials, config, false, false) { }

        public BenchPipelineClient(AWSCredentials credentials, ClientConfig config, bool endpointRules, bool endpointDiscovery) : base(credentials, config)
        {
            _endpointDiscovery = endpointDiscovery;
            if (endpointRules)
            {
                // CustomizeRuntimePipeline runs in the base constructor, before the field is set, so the
                // endpoint resolver is swapped in here instead.
                RuntimePipeline.RemoveHandler<EndpointResolver>();
                RuntimePipeline.AddHandlerAfter<BenchAuthSchemeHandler>(new BenchEndpointResolver());
            }
        }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
        {
            // Same placement as the generated service clients.
            pipeline.AddHandlerAfter<Marshaller>(new BenchAuthSchemeHandler());
        }

        public BenchPipelineResponse Call(BenchPipelineRequest request)
        {
            return Invoke<BenchPipelineResponse>(request, CreateOptions());
        }

        public Task<BenchPipelineResponse> CallAsync(BenchPipelineRequest request)
        {
            return InvokeAsync<BenchPipelineResponse>(request, CreateOptions(), default);
        }

        private InvokeOptions CreateOptions()
        {
            var options = new InvokeOptions
            {
                RequestMarshaller = BenchRequestMarshaller.Instance,
                ResponseUnmarshaller = BenchResponseUnmarshaller.Instance,
            };
            if (_endpointDiscovery)
            {
                // As the generated clients do for operations with endpoint discovery.
                options.EndpointDiscoveryMarshaller = BenchEndpointDiscoveryMarshaller.Instance;
                options.EndpointOperation = EndpointOperation;
            }
            return options;
        }

        // As the generated clients implement it: resolve from the client's endpoint cache, calling the
        // DescribeEndpoints-like operation only when the cache has nothing for the key.
        protected override IEnumerable<DiscoveryEndpointBase> EndpointOperation(EndpointOperationContextBase context)
        {
            return EndpointDiscoveryResolver.ResolveEndpoints(context, () => new List<DiscoveryEndpointBase>
            {
                new DiscoveryEndpoint("ingest-cell2.timestream.us-west-2.amazonaws.com", 1440)
            });
        }
    }

    private sealed class BenchAuthSchemeHandler : BaseAuthResolverHandler
    {
        public static List<IAuthSchemeOption> FromEndpoint(Amazon.Runtime.Endpoints.Endpoint endpoint) => RetrieveSchemesFromEndpoint(endpoint);

        protected override List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext)
            => AuthSchemeOption.DEFAULT_SIGV4;
    }

    // Endpoint discovery data for an operation that requires discovery and has no identifiers (Timestream's shape).
    private sealed class BenchEndpointDiscoveryMarshaller : IMarshaller<EndpointDiscoveryDataBase, AmazonWebServiceRequest>
    {
        public static readonly BenchEndpointDiscoveryMarshaller Instance = new();

        public EndpointDiscoveryDataBase Marshall(AmazonWebServiceRequest input) => new EndpointDiscoveryData(true);
    }

    // A BaseEndpointResolver subclass shaped like the generated ones (for example AmazonDynamoDBEndpointResolver).
    private sealed class BenchEndpointResolver : BaseEndpointResolver
    {
        protected override Amazon.Runtime.Endpoints.EndpointParameters MapEndpointsParameters(IRequestContext requestContext)
        {
            var result = new Amazon.Runtime.Endpoints.EndpointParameters();
            result["Region"] = requestContext.ClientConfig.RegionEndpoint?.SystemName;
            result["UseDualStack"] = requestContext.ClientConfig.UseDualstackEndpoint;
            result["UseFIPS"] = requestContext.ClientConfig.UseFIPSEndpoint;
            result["Endpoint"] = requestContext.ClientConfig.ServiceURL;
            return result;
        }
    }

    // Returns a new endpoint with a newly built URL on every call, without a trailing slash, as the rules do.
    private sealed class BenchEndpointProvider : Amazon.Runtime.Endpoints.IEndpointProvider
    {
        public static readonly BenchEndpointProvider Instance = new();

        public Amazon.Runtime.Endpoints.Endpoint ResolveEndpoint(Amazon.Runtime.Endpoints.EndpointParameters parameters)
            => new Amazon.Runtime.Endpoints.Endpoint("https://dynamodb." + (string)parameters["Region"] + ".amazonaws.com");
    }

    private sealed class BenchRequestMarshaller : IMarshaller<IRequest, AmazonWebServiceRequest>
    {
        public static readonly BenchRequestMarshaller Instance = new();

        private static readonly byte[] Body = Encoding.UTF8.GetBytes(
            "{\"TableName\":\"my-table\",\"Key\":{\"pk\":{\"S\":\"user#12345\"},\"sk\":{\"S\":\"profile\"}},\"ConsistentRead\":true}");

        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            IRequest request = new DefaultRequest(input, "AmazonDynamoDBv2");
            request.Headers["X-Amz-Target"] = "DynamoDB_20120810.GetItem";
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";
            request.ResourcePath = "/";
            request.Content = Body;
            return request;
        }
    }

    private sealed class BenchResponseUnmarshaller : JsonResponseUnmarshaller
    {
        public static readonly BenchResponseUnmarshaller Instance = new();

        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
            var response = new BenchPipelineResponse();
            var reader = new StreamingUtf8JsonReader(context.Stream, AWSConfigs.StreamingUtf8JsonReaderBufferSize ?? 4096, context.JsonMaxDepth);
            context.Read(ref reader);
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth, ref reader))
            {
                if (context.TestExpression("ReadCapacity", targetDepth, ref reader))
                {
                    response.ReadCapacity = NullableLongUnmarshaller.Instance.Unmarshall(context, ref reader);
                    continue;
                }
                if (context.TestExpression("WriteCapacity", targetDepth, ref reader))
                {
                    response.WriteCapacity = NullableLongUnmarshaller.Instance.Unmarshall(context, ref reader);
                    continue;
                }
            }
            return response;
        }

        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            var reader = new StreamingUtf8JsonReader(context.Stream, AWSConfigs.StreamingUtf8JsonReaderBufferSize ?? 4096, context.JsonMaxDepth);
            var errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context, ref reader);
            return new AmazonServiceException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
        }
    }

    private sealed class FakeHttpClientFactory : HttpClientFactory
    {
        private readonly bool _yield;
        private readonly bool _error;
        private readonly bool _manyHeaders;

        public FakeHttpClientFactory(bool yieldInHandler, bool error, bool manyHeaders)
        {
            _yield = yieldInHandler;
            _error = error;
            _manyHeaders = manyHeaders;
        }

        public override HttpClient CreateHttpClient(IClientConfig clientConfig) => new HttpClient(new FakeHttpMessageHandler(_yield, _error, _manyHeaders));
    }

    private sealed class FakeHttpMessageHandler : HttpMessageHandler
    {
        private static readonly byte[] ResponseBody = Encoding.UTF8.GetBytes("{\"ReadCapacity\":10,\"WriteCapacity\":5}");
        private static readonly byte[] ErrorBody = Encoding.UTF8.GetBytes(
            "{\"__type\":\"com.amazonaws.dynamodb.v20120810#ConditionalCheckFailedException\",\"message\":\"The conditional request failed\"}");
        private readonly bool _yield;
        private readonly bool _error;
        private readonly bool _manyHeaders;

        public FakeHttpMessageHandler(bool yieldInHandler, bool error, bool manyHeaders)
        {
            _yield = yieldInHandler;
            _error = error;
            _manyHeaders = manyHeaders;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            => CreateResponse(request, _error, _manyHeaders);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_yield)
                await Task.Yield();
            return CreateResponse(request, _error, _manyHeaders);
        }

        private static HttpResponseMessage CreateResponse(HttpRequestMessage request, bool error, bool manyHeaders)
        {
            var response = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK)
            {
                RequestMessage = request,
                Content = new ByteArrayContent(error ? ErrorBody : ResponseBody),
            };
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/x-amz-json-1.0");
            response.Headers.TryAddWithoutValidation("x-amzn-RequestId", "4KHM2B6DFM8QOVQ1TQ6BJPO5O3VV4KQNSO5AEMVJF66Q9ASUAAJG");
            response.Headers.Date = DateTimeOffset.UtcNow;
            if (manyHeaders)
            {
                response.Headers.TryAddWithoutValidation("x-amz-id-2", "vlR7PnpV2Ce81l0PRw6jlUpck7Jo5ZsQjryTjKlc5aLWGVHPZLj5NeC6qMa0emYBDXOo6QBU0Wo=");
                response.Headers.TryAddWithoutValidation("x-amz-request-id", "5HM0Z9GBP1BC9QX3");
                response.Headers.TryAddWithoutValidation("x-amz-server-side-encryption", "AES256");
                response.Headers.TryAddWithoutValidation("x-amz-version-id", "3HL4kqtJlcpXroDTDmJ.rmSpXd3dIbrHY");
                response.Headers.TryAddWithoutValidation("ETag", "\"6805f2cfc46c0f04559748bb039d69ae\"");
                response.Headers.TryAddWithoutValidation("Accept-Ranges", "bytes");
                response.Headers.TryAddWithoutValidation("Server", "AmazonS3");
                response.Content.Headers.TryAddWithoutValidation("Last-Modified", "Thu, 19 Nov 2026 18:22:45 GMT");
            }
            return response;
        }
    }

    private sealed class BenchPipelineConfig : ClientConfig
    {
        public BenchPipelineConfig() : base(new Provider()) { }

        public override string RegionEndpointServiceName => "dynamodb";
        public override string ServiceVersion => "2012-08-10";
        public override string UserAgent => "aws-sdk-dotnet-bench/1.0";

        public override Amazon.Runtime.Endpoints.Endpoint DetermineServiceOperationEndpoint(Amazon.Runtime.Endpoints.ServiceOperationEndpointParameters parameters)
            => new Amazon.Runtime.Endpoints.Endpoint("https://dynamodb.us-west-2.amazonaws.com");

        private sealed class Provider : IDefaultConfigurationProvider
        {
            public IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null)
                => new DefaultConfiguration();
        }
    }
}
