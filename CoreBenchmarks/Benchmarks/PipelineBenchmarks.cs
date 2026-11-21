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
    private BenchPipelineRequest _request;

    [GlobalSetup]
    public void Setup()
    {
        _client = CreateClient(yieldInHandler: false);
        _yieldingClient = CreateClient(yieldInHandler: true);
        _errorClient = CreateClient(yieldInHandler: false, error: true);
        _yieldingErrorClient = CreateClient(yieldInHandler: true, error: true);
        _request = new BenchPipelineRequest();

        // Warm up connection caches, user-agent caches and similar one-time state.
        _client.Call(_request);
        _client.CallAsync(_request).GetAwaiter().GetResult();
        _yieldingClient.CallAsync(_request).GetAwaiter().GetResult();
        InvokeSync_ServiceError();
        InvokeAsync_ServiceError_Yielding().GetAwaiter().GetResult();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _client?.Dispose();
        _yieldingClient?.Dispose();
        _errorClient?.Dispose();
        _yieldingErrorClient?.Dispose();
    }

    private static BenchPipelineClient CreateClient(bool yieldInHandler, bool error = false)
    {
        var config = new BenchPipelineConfig
        {
            RegionEndpoint = RegionEndpoint.USWest2,
            AuthenticationServiceName = "dynamodb",
            HttpClientFactory = new FakeHttpClientFactory(yieldInHandler, error),
        };
        return new BenchPipelineClient(new BasicAWSCredentials("AKIDEXAMPLE", "wJalrXUtnFEMI/K7MDENG+bPxRfiCYEXAMPLEKEY"), config);
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

    public sealed class BenchPipelineRequest : AmazonWebServiceRequest { }

    public sealed class BenchPipelineResponse : AmazonWebServiceResponse
    {
        public long? ReadCapacity { get; set; }
        public long? WriteCapacity { get; set; }
    }

    private sealed class BenchPipelineClient : AmazonServiceClient
    {
        public BenchPipelineClient(AWSCredentials credentials, ClientConfig config) : base(credentials, config) { }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
        {
            // Same placement as the generated service clients.
            pipeline.AddHandlerAfter<Marshaller>(new BenchAuthSchemeHandler());
        }

        public BenchPipelineResponse Call(BenchPipelineRequest request)
        {
            var options = new InvokeOptions
            {
                RequestMarshaller = BenchRequestMarshaller.Instance,
                ResponseUnmarshaller = BenchResponseUnmarshaller.Instance,
            };
            return Invoke<BenchPipelineResponse>(request, options);
        }

        public Task<BenchPipelineResponse> CallAsync(BenchPipelineRequest request)
        {
            var options = new InvokeOptions
            {
                RequestMarshaller = BenchRequestMarshaller.Instance,
                ResponseUnmarshaller = BenchResponseUnmarshaller.Instance,
            };
            return InvokeAsync<BenchPipelineResponse>(request, options, default);
        }
    }

    private sealed class BenchAuthSchemeHandler : BaseAuthResolverHandler
    {
        protected override List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext)
            => AuthSchemeOption.DEFAULT_SIGV4;
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

        public FakeHttpClientFactory(bool yieldInHandler, bool error)
        {
            _yield = yieldInHandler;
            _error = error;
        }

        public override HttpClient CreateHttpClient(IClientConfig clientConfig) => new HttpClient(new FakeHttpMessageHandler(_yield, _error));
    }

    private sealed class FakeHttpMessageHandler : HttpMessageHandler
    {
        private static readonly byte[] ResponseBody = Encoding.UTF8.GetBytes("{\"ReadCapacity\":10,\"WriteCapacity\":5}");
        private static readonly byte[] ErrorBody = Encoding.UTF8.GetBytes(
            "{\"__type\":\"com.amazonaws.dynamodb.v20120810#ConditionalCheckFailedException\",\"message\":\"The conditional request failed\"}");
        private readonly bool _yield;
        private readonly bool _error;

        public FakeHttpMessageHandler(bool yieldInHandler, bool error)
        {
            _yield = yieldInHandler;
            _error = error;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            => CreateResponse(request, _error);

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_yield)
                await Task.Yield();
            return CreateResponse(request, _error);
        }

        private static HttpResponseMessage CreateResponse(HttpRequestMessage request, bool error)
        {
            var response = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK)
            {
                RequestMessage = request,
                Content = new ByteArrayContent(error ? ErrorBody : ResponseBody),
            };
            response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/x-amz-json-1.0");
            response.Headers.TryAddWithoutValidation("x-amzn-RequestId", "4KHM2B6DFM8QOVQ1TQ6BJPO5O3VV4KQNSO5AEMVJF66Q9ASUAAJG");
            response.Headers.Date = DateTimeOffset.UtcNow;
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
