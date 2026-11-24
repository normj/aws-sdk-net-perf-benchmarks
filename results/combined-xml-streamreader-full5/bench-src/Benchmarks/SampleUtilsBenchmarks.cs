using Amazon.Util;
using BenchmarkDotNet.Attributes;

namespace CoreBenchmarks.Benchmarks;

// Sample benchmark used to validate ab.sh. Workers add one class per area
// (for example SigningBenchmarks, PipelineBenchmarks) on main of this repo.
// Benchmarks must only call APIs that exist on the base commit, because ab.sh
// runs the same benchmark source against both base and PR builds of Core.
[MemoryDiagnoser]
public class SampleUtilsBenchmarks
{
    private string _path;
    private byte[] _hash;

    [GlobalSetup]
    public void Setup()
    {
        _path = "/my-bucket/some folder/object key with spaces & symbols (1).txt";
        _hash = new byte[32];
        new Random(42).NextBytes(_hash);
    }

    [Benchmark]
    public string UrlEncode_Path() => AWSSDKUtils.UrlEncode(_path, path: true);

    [Benchmark]
    public string ToHex_Lowercase() => AWSSDKUtils.ToHex(_hash, lowercase: true);
}
