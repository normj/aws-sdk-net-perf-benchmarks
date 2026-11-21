using BenchmarkDotNet.Running;

namespace CoreBenchmarks;

public static class Program
{
    // Run through ab.sh for A/B comparisons. Direct use:
    //   dotnet run -c Release -f net10.0 -- --filter '*UrlEncode*' --runtimes net10.0 net11.0
    public static void Main(string[] args)
        => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}
