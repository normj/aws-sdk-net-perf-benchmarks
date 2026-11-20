```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.45 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.398 μs | 0.0388 μs | 0.0324 μs | 0.1068 |   2.98 KB |
| Sign_S3GetWithQuery | 5.789 μs | 0.0423 μs | 0.0375 μs | 0.1221 |   3.41 KB |
| Presign_S3GetObject | 6.551 μs | 0.0584 μs | 0.0518 μs | 0.2213 |   6.12 KB |
