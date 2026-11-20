```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.17 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 5.815 μs | 0.0282 μs | 0.0264 μs | 0.1297 |   3.73 KB |
| Sign_S3GetWithQuery | 5.207 μs | 0.0139 μs | 0.0123 μs | 0.1373 |   3.98 KB |
| Presign_S3GetObject | 6.018 μs | 0.0220 μs | 0.0195 μs | 0.2365 |   6.63 KB |
