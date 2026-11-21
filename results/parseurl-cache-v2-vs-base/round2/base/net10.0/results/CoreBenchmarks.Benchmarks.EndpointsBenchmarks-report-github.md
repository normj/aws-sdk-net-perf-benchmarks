```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                  | Mean     | Error   | StdDev  | Gen0   | Allocated |
|------------------------ |---------:|--------:|--------:|-------:|----------:|
| ParseURL_CustomEndpoint | 716.4 ns | 4.83 ns | 2.88 ns | 0.0346 |     984 B |
| ParseURL_WithPath       | 670.8 ns | 5.64 ns | 3.73 ns | 0.0321 |     968 B |
