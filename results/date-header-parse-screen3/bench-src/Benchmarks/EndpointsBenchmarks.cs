using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using BenchmarkDotNet.Attributes;
using static Amazon.Runtime.Internal.Endpoints.StandardLibrary.Fn;

namespace CoreBenchmarks.Benchmarks;

// Endpoint rule evaluation microbenchmarks. Generated service endpoint providers live in the
// service packages, which this project does not reference, so the two *_Resolve benchmarks
// replay the exact sequence of standard-library calls that the generated S3 and DynamoDB
// providers make for their most common path (a virtual-hosted S3 bucket in us-west-2, and a
// DynamoDB call in us-west-2 with no options). The other benchmarks isolate one Fn call each.
// Only APIs that exist on the base commit are used (ab.sh runs this source against both sides).
[MemoryDiagnoser]
public class EndpointsBenchmarks
{
    private const string S3AuthSchemes =
        @"{""authSchemes"":[{""disableDoubleEncoding"":true,""name"":""sigv4"",""signingName"":""s3"",""signingRegion"":""{Region}""}]}";

    private EndpointParameters _s3Params;
    private EndpointParameters _ddbParams;
    private Dictionary<string, object> _s3Refs;
    private Arn _arn;

    [GlobalSetup]
    public void Setup()
    {
        _s3Params = new EndpointParameters();
        _s3Params["Bucket"] = "my-application-bucket";
        _s3Params["Region"] = "us-west-2";
        _s3Params["UseFIPS"] = false;
        _s3Params["UseDualStack"] = false;
        _s3Params["ForcePathStyle"] = false;
        _s3Params["Accelerate"] = false;
        _s3Params["UseGlobalEndpoint"] = false;
        _s3Params["DisableMultiRegionAccessPoints"] = false;
        _s3Params["Key"] = "logs/2026/11/20/app.log";

        _ddbParams = new EndpointParameters();
        _ddbParams["Region"] = "us-west-2";
        _ddbParams["UseFIPS"] = false;
        _ddbParams["UseDualStack"] = false;
        _ddbParams["AccountIdEndpointMode"] = "preferred";
        _ddbParams["ResourceArn"] = "my-table";

        _s3Refs = new Dictionary<string, object>
        {
            ["Bucket"] = "my-application-bucket",
            ["Region"] = "us-west-2",
            ["partitionResult"] = Partition("us-west-2"),
        };
        _arn = ParseArn("arn:aws:s3:us-west-2:123456789012:accesspoint:my-endpoint");
    }

    // Replays AmazonS3EndpointProvider for a virtual-hosted bucket in us-west-2.
    [Benchmark]
    public Endpoint S3_Resolve()
    {
        var p = _s3Params;
        var refs = new Dictionary<string, object>()
        {
            ["Bucket"] = p["Bucket"],
            ["Region"] = p["Region"],
            ["UseFIPS"] = p["UseFIPS"],
            ["UseDualStack"] = p["UseDualStack"],
            ["Endpoint"] = p["Endpoint"],
            ["ForcePathStyle"] = p["ForcePathStyle"],
            ["Accelerate"] = p["Accelerate"],
            ["UseGlobalEndpoint"] = p["UseGlobalEndpoint"],
            ["UseObjectLambdaEndpoint"] = p["UseObjectLambdaEndpoint"],
            ["Key"] = p["Key"],
            ["Prefix"] = p["Prefix"],
            ["CopySource"] = p["CopySource"],
            ["DisableAccessPoints"] = p["DisableAccessPoints"],
            ["DisableMultiRegionAccessPoints"] = p["DisableMultiRegionAccessPoints"],
            ["UseArnRegion"] = p["UseArnRegion"],
            ["UseS3ExpressControlEndpoint"] = p["UseS3ExpressControlEndpoint"],
            ["DisableS3ExpressSessionAuth"] = p["DisableS3ExpressSessionAuth"],
        };
        if (IsSet(refs["Region"]))
        {
            if (IsSet(refs["Bucket"]) && (refs["bucketSuffix"] = Substring((string)refs["Bucket"], 0, 6, true)) != null && Equals(refs["bucketSuffix"], "--x-s3"))
            {
                throw new InvalidOperationException("unexpected S3 Express path");
            }
            if (IsSet(refs["Bucket"]) && (refs["accessPointSuffix"] = Substring((string)refs["Bucket"], 0, 7, true)) != null && Equals(refs["accessPointSuffix"], "--xa-s3"))
            {
                throw new InvalidOperationException("unexpected access point path");
            }
            if (IsSet(refs["Bucket"]) && (refs["hardwareType"] = Substring((string)refs["Bucket"], 49, 50, true)) != null)
            {
                throw new InvalidOperationException("unexpected outposts path");
            }
            if (IsSet(refs["Bucket"]))
            {
                if (Equals(refs["ForcePathStyle"], false) && IsVirtualHostableS3Bucket((string)refs["Bucket"], false))
                {
                    if ((refs["partitionResult"] = Partition((string)refs["Region"])) != null)
                    {
                        if (IsValidHostLabel((string)refs["Region"], false))
                        {
                            if (Equals(refs["Accelerate"], true) && Equals(GetAttr(refs["partitionResult"], "name"), "aws-cn"))
                            {
                                throw new InvalidOperationException();
                            }
                            if (Equals(refs["UseDualStack"], false) && Equals(refs["UseFIPS"], false) && Equals(refs["Accelerate"], false) && !IsSet(refs["Endpoint"]) && !Equals(refs["Region"], "aws-global") && Equals(refs["UseGlobalEndpoint"], false))
                            {
                                return new Endpoint(Interpolate(@"https://{Bucket}.s3.{Region}.{partitionResult#dnsSuffix}", refs), InterpolateJson(S3AuthSchemes, refs), InterpolateJson(@"", refs));
                            }
                        }
                    }
                }
            }
        }
        throw new InvalidOperationException("unexpected path");
    }

    // Replays AmazonDynamoDBEndpointProvider for a plain us-west-2 call with no account id.
    [Benchmark]
    public Endpoint DynamoDB_Resolve()
    {
        var p = _ddbParams;
        var refs = new Dictionary<string, object>()
        {
            ["Region"] = p["Region"],
            ["UseDualStack"] = p["UseDualStack"],
            ["UseFIPS"] = p["UseFIPS"],
            ["Endpoint"] = p["Endpoint"],
            ["AccountId"] = p["AccountId"],
            ["AccountIdEndpointMode"] = p["AccountIdEndpointMode"],
            ["ResourceArn"] = p["ResourceArn"],
            ["ResourceArnList"] = p["ResourceArnList"],
            ["IsSearchOperation"] = p["IsSearchOperation"],
        };
        if (IsSet(refs["Region"]))
        {
            if ((refs["PartitionResult"] = Partition((string)refs["Region"])) != null)
            {
                if (Equals(refs["Region"], "local")) throw new InvalidOperationException();
                if (IsSet(refs["AccountIdEndpointMode"]) && !Equals(refs["AccountIdEndpointMode"], "disabled") && !Equals(refs["UseFIPS"], true) && IsSet(refs["ResourceArn"]) && (refs["ParsedArn"] = ParseArn((string)refs["ResourceArn"])) != null)
                {
                    throw new InvalidOperationException();
                }
                if (Equals(GetAttr(refs["PartitionResult"], "name"), "aws-us-gov")) throw new InvalidOperationException();
                return new Endpoint(Interpolate(@"https://dynamodb.{Region}.{PartitionResult#dnsSuffix}", refs), InterpolateJson(@"", refs), InterpolateJson(@"", refs));
            }
        }
        throw new InvalidOperationException("unexpected path");
    }

    [Benchmark]
    public bool IsVirtualHostableS3Bucket_NoDots() => IsVirtualHostableS3Bucket("my-application-bucket", false);

    [Benchmark]
    public bool IsValidHostLabel_Region() => IsValidHostLabel("us-west-2", false);

    [Benchmark]
    public bool IsValidHostLabel_SubDomains() => IsValidHostLabel("my.dotted.bucket.name", true);

    [Benchmark]
    public string Substring_Suffix() => Substring("my-application-bucket", 0, 6, true);

    [Benchmark]
    public Arn ParseArn_NotArn() => ParseArn("my-application-bucket");

    [Benchmark]
    public Arn ParseArn_AccessPoint() => ParseArn("arn:aws:s3:us-west-2:123456789012:accesspoint:my-endpoint");

    [Benchmark]
    public string Interpolate_Url() => Interpolate(@"https://{Bucket}.s3.{Region}.{partitionResult#dnsSuffix}", _s3Refs);

    [Benchmark]
    public string InterpolateJson_AuthSchemes() => InterpolateJson(S3AuthSchemes, _s3Refs);

    [Benchmark]
    public Endpoint Endpoint_WithAttributes() =>
        new Endpoint("https://my-application-bucket.s3.us-west-2.amazonaws.com",
            @"{""authSchemes"":[{""disableDoubleEncoding"":true,""name"":""sigv4"",""signingName"":""s3"",""signingRegion"":""us-west-2""}]}",
            "");

    [Benchmark]
    public Partition Partition_KnownRegion() => Partition("us-west-2");

    // Generated rules mostly read a single property, e.g. GetAttr(refs["PartitionResult"], "name").
    [Benchmark]
    public object GetAttr_SingleSegment() => GetAttr(_s3Refs["partitionResult"], "name");

    // Rules call ParseURL(refs["Endpoint"]) on every request when the client has a custom ServiceURL.
    [Benchmark]
    public URL ParseURL_CustomEndpoint() => ParseURL("https://vpce-0a1b2c3d4e5f.s3.us-west-2.vpce.amazonaws.com");

    [Benchmark]
    public URL ParseURL_WithPath() => ParseURL("http://localhost:4566/custom/path");

    [Benchmark]
    public object GetAttr_Indexed() => GetAttr(_arn, "resourceId[1]");
}
