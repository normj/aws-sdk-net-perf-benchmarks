```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.15 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost       | 7.072 μs | 0.4096 μs | 1.2013 μs | 6.392 μs | 0.1068 |   2.98 KB |
| Sign_S3GetWithQuery | 5.617 μs | 0.1091 μs | 0.1340 μs | 5.592 μs | 0.1221 |   3.41 KB |
| Presign_S3GetObject | 6.564 μs | 0.1209 μs | 0.1131 μs | 6.524 μs | 0.2213 |   6.12 KB |
