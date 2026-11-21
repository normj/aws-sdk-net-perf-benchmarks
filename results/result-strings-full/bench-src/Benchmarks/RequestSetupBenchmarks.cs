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
    }

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
}
