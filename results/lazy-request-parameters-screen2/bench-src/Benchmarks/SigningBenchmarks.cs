using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using BenchmarkDotNet.Attributes;

namespace CoreBenchmarks.Benchmarks;

// SigV4 signing microbenchmarks. Each benchmark re-signs the same request object, which is what
// the SDK does on retries: InitializeHeaders/CleanHeaders strip the previous Authorization and
// x-amz-content-sha256 headers first, so each iteration does the full signing work.
// Only APIs that exist on the base commit are used (ab.sh runs this source against both sides).
[MemoryDiagnoser]
public class SigningBenchmarks
{
    private const string AccessKey = "AKIDEXAMPLE";
    private const string SecretKey = "wJalrXUtnFEMI/K7MDENG+bPxRfiCYEXAMPLEKEY";
    private const string SessionToken =
        "IQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2VjEXAMPLE" +
        "TOKENFQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2VjEXAMPLETOKENFQoJb3JpZ2luX2Vj";

    private AWS4Signer _signer;
    private BenchClientConfig _jsonConfig;
    private BenchClientConfig _s3Config;
    private AWSCredentials _credentials;
    private RequestMetrics _metrics;
    private IRequest _jsonPost;
    private IRequest _s3Get;
    private IRequest _s3Presign;
    private IRequest _restJsonPost;
    private IRequest _s3GetObject;
    private Uri _lambdaEndpoint;
    private Uri _s3Endpoint;
    private Dictionary<string, string> _lambdaPathResources;
    private Dictionary<string, string> _s3KeyPathResources;

    [GlobalSetup]
    public void Setup()
    {
        _signer = new AWS4Signer();
        _jsonConfig = new BenchClientConfig { AuthenticationServiceName = "dynamodb", AuthenticationRegion = "us-west-2" };
        _s3Config = new BenchClientConfig { AuthenticationServiceName = "s3", AuthenticationRegion = "us-west-2" };
        _credentials = new SessionAWSCredentials(AccessKey, SecretKey, SessionToken);
        _metrics = new RequestMetrics();

        // DynamoDB GetItem-shaped JSON POST.
        _jsonPost = new DefaultRequest(new StubRequest(), "AmazonDynamoDBv2")
        {
            HttpMethod = "POST",
            Endpoint = new Uri("https://dynamodb.us-west-2.amazonaws.com"),
            ResourcePath = "/",
            AuthenticationRegion = "us-west-2",
            Content = Encoding.UTF8.GetBytes(
                "{\"TableName\":\"my-table\",\"Key\":{\"pk\":{\"S\":\"user#12345\"},\"sk\":{\"S\":\"profile\"}},\"ConsistentRead\":true}"),
        };
        AddCommonHeaders(_jsonPost);
        _jsonPost.Headers["Content-Type"] = "application/x-amz-json-1.0";
        _jsonPost.Headers["X-Amz-Target"] = "DynamoDB_20120810.GetItem";
        _jsonPost.Headers["Content-Length"] = _jsonPost.Content.Length.ToString();

        // S3 ListObjectsV2-shaped GET with query parameters and an unsigned payload.
        _s3Get = new DefaultRequest(new StubRequest(), "AmazonS3")
        {
            HttpMethod = "GET",
            Endpoint = new Uri("https://my-bucket.s3.us-west-2.amazonaws.com"),
            ResourcePath = "/",
            AuthenticationRegion = "us-west-2",
            DisablePayloadSigning = true,
        };
        AddCommonHeaders(_s3Get);
        _s3Get.Parameters["list-type"] = "2";
        _s3Get.Parameters["prefix"] = "logs/2026/11/20/";
        _s3Get.Parameters["max-keys"] = "1000";
        _s3Get.Parameters["continuation-token"] = "1ueGcxLPRx1Tr/XYExHnhbYLgveDs2J/wm36Hy4vbOwM=";
        _s3Get.UseQueryString = true;

        // S3 GetObject presigned URL for a key with characters that need encoding.
        _s3Presign = new DefaultRequest(new StubRequest(), "AmazonS3")
        {
            HttpMethod = "GET",
            Endpoint = new Uri("https://my-bucket.s3.us-west-2.amazonaws.com"),
            ResourcePath = "/reports/2026/Q4 summary (final).pdf",
            AuthenticationRegion = "us-west-2",
        };
        _s3Presign.Parameters["X-Amz-Expires"] = "3600";
        _s3Presign.Parameters["X-Amz-Security-Token"] = SessionToken;
        _s3Presign.UseQueryString = true;

        // Lambda Invoke-shaped REST-JSON POST: a resource path with a label, signed with double encoding.
        var lambdaConfig = new BenchClientConfig { AuthenticationServiceName = "lambda", AuthenticationRegion = "us-west-2" };
        _lambdaConfig = lambdaConfig;
        _lambdaEndpoint = new Uri("https://lambda.us-west-2.amazonaws.com");
        _restJsonPost = new DefaultRequest(new StubRequest(), "AmazonLambda")
        {
            HttpMethod = "POST",
            Endpoint = _lambdaEndpoint,
            ResourcePath = "/2015-03-31/functions/{FunctionName}/invocations",
            AuthenticationRegion = "us-west-2",
            Content = Encoding.UTF8.GetBytes("{\"orderId\":\"12345\"}"),
        };
        _restJsonPost.AddPathResource("{FunctionName}", "my-function:prod");
        AddCommonHeaders(_restJsonPost);
        _restJsonPost.Headers["Content-Type"] = "application/json";
        _restJsonPost.Headers["Content-Length"] = _restJsonPost.Content.Length.ToString();
        _lambdaPathResources = new Dictionary<string, string> { { "{FunctionName}", "my-function:prod" } };

        // S3 GetObject-shaped GET: a greedy key label with characters that need encoding.
        _s3Endpoint = new Uri("https://my-bucket.s3.us-west-2.amazonaws.com");
        _s3GetObject = new DefaultRequest(new StubRequest(), "AmazonS3")
        {
            HttpMethod = "GET",
            Endpoint = _s3Endpoint,
            ResourcePath = "/{Key+}",
            AuthenticationRegion = "us-west-2",
            DisablePayloadSigning = true,
        };
        _s3GetObject.AddPathResource("{Key+}", "photos/2026/11/20/IMG 0001 (copy).jpg");
        AddCommonHeaders(_s3GetObject);
        _s3KeyPathResources = new Dictionary<string, string> { { "{Key+}", "photos/2026/11/20/IMG 0001 (copy).jpg" } };
    }

    private BenchClientConfig _lambdaConfig;

    private static void AddCommonHeaders(IRequest request)
    {
        request.Headers["User-Agent"] = "aws-sdk-dotnet-coreclr/4.0.0.0 ua/2.0 os/linux lang/.NET_Core#10.0 md/aws-sdk-dotnet-core#4.0.0.0";
        request.Headers["amz-sdk-invocation-id"] = "c2b5f9f0-6c36-4c8b-9a3b-0e4f9f1c6a11";
        request.Headers["amz-sdk-request"] = "attempt=1; max=3";
        request.Headers["X-Amz-Security-Token"] = SessionToken;
    }

    [Benchmark]
    public string Sign_JsonPost()
    {
        _signer.Sign(_jsonPost, _jsonConfig, _metrics, _credentials);
        return _jsonPost.Headers["Authorization"];
    }

    [Benchmark]
    public string Sign_S3GetWithQuery()
    {
        _signer.Sign(_s3Get, _s3Config, _metrics, _credentials);
        return _s3Get.Headers["Authorization"];
    }

    [Benchmark]
    public string Presign_S3GetObject()
    {
        var result = AWS4PreSignedUrlSigner.SignRequest(_s3Presign, _s3Config, _metrics, AccessKey, SecretKey, "s3", "us-west-2");
        return result.ForQueryParameters;
    }

    [Benchmark]
    public string Sign_RestJsonPathResources()
    {
        _signer.Sign(_restJsonPost, _lambdaConfig, _metrics, _credentials);
        return _restJsonPost.Headers["Authorization"];
    }

    [Benchmark]
    public string Sign_S3GetObjectKey()
    {
        _signer.Sign(_s3GetObject, _s3Config, _metrics, _credentials);
        return _s3GetObject.Headers["Authorization"];
    }

    [Benchmark]
    public string CanonicalizeResourcePath_RestJson()
        => AWSSDKUtils.CanonicalizeResourcePathV2(_lambdaEndpoint, "/2015-03-31/functions/{FunctionName}/invocations", true, _lambdaPathResources);

    [Benchmark]
    public string CanonicalizeResourcePath_S3Key()
        => AWSSDKUtils.CanonicalizeResourcePathV2(_s3Endpoint, "/{Key+}", false, _s3KeyPathResources);

    // The DynamoDB GetItem body in a PooledContentStream, which is how the generated JSON, XML and CBOR
    // marshallers hand the body to the signer. DefaultRequest caches the content stream hash, so each
    // invocation builds a fresh request around the same pooled body.
    private PooledContentStream _pooledJsonBody;

    private PooledContentStream PooledJsonBody()
    {
        if (_pooledJsonBody == null)
        {
            _pooledJsonBody = new PooledContentStream();
            var body = _jsonPost.Content;
            body.CopyTo(_pooledJsonBody.BufferWriter.GetSpan(body.Length));
            _pooledJsonBody.BufferWriter.Advance(body.Length);
        }
        return _pooledJsonBody;
    }

    private IRequest NewPooledJsonPost()
    {
        var request = new DefaultRequest(new StubRequest(), "AmazonDynamoDBv2")
        {
            HttpMethod = "POST",
            Endpoint = _jsonPost.Endpoint,
            ResourcePath = "/",
            AuthenticationRegion = "us-west-2",
            ContentStream = PooledJsonBody(),
        };
        AddCommonHeaders(request);
        request.Headers["Content-Type"] = "application/x-amz-json-1.0";
        request.Headers["X-Amz-Target"] = "DynamoDB_20120810.GetItem";
        request.Headers["Content-Length"] = _jsonPost.Headers["Content-Length"];
        return request;
    }

    [Benchmark]
    public string Sign_JsonPostPooledBody()
    {
        var request = NewPooledJsonPost();
        _signer.Sign(request, _jsonConfig, _metrics, _credentials);
        return request.Headers["Authorization"];
    }

    [Benchmark]
    public string ContentStreamHash_PooledJson()
    {
        var request = new DefaultRequest(new StubRequest(), "AmazonDynamoDBv2") { ContentStream = PooledJsonBody() };
        return request.ComputeContentStreamHash();
    }

    // A SHA-256 sized value: the canonical request hash, payload hash and signature are all hex-encoded from 32 bytes.
    private static readonly byte[] _hash32 = System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes("SigningBenchmarks"));

    [Benchmark]
    public string ToHex_Sha256Lower() => AWSSDKUtils.ToHex(_hash32, true);

    private sealed class StubRequest : AmazonWebServiceRequest { }

    private sealed class BenchClientConfig : ClientConfig
    {
        public BenchClientConfig() : base(new Provider()) { }

        public override string RegionEndpointServiceName => "bench";
        public override string ServiceVersion => "Bench";
        public override string UserAgent => "Bench";

        public override Amazon.Runtime.Endpoints.Endpoint DetermineServiceOperationEndpoint(Amazon.Runtime.Endpoints.ServiceOperationEndpointParameters parameters)
            => new Amazon.Runtime.Endpoints.Endpoint("https://example.com");

        private sealed class Provider : IDefaultConfigurationProvider
        {
            public IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null)
                => new DefaultConfiguration();
        }
    }
}
