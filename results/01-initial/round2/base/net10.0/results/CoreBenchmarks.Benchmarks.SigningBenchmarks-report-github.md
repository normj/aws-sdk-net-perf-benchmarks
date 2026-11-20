```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.11 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.073 μs | 0.0322 μs | 0.0285 μs | 0.1526 |   4.29 KB |
| Sign_S3GetWithQuery | 5.488 μs | 0.0171 μs | 0.0160 μs | 0.1602 |   4.51 KB |
| Presign_S3GetObject | 6.440 μs | 0.0279 μs | 0.0247 μs | 0.2594 |   7.16 KB |
