```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                             | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------------------- |----------:|---------:|---------:|-------:|----------:|
| EndpointAuthSchemes_SingleSigV4    |  97.51 ns | 0.360 ns | 0.188 ns | 0.0074 |     216 B |
| EndpointAuthSchemes_SigV4aAndSigV4 | 171.13 ns | 1.653 ns | 0.984 ns | 0.0122 |     360 B |
