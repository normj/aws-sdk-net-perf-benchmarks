```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.66 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.439 μs | 0.0784 μs | 0.0695 μs | 0.1068 |   2.98 KB |
| Sign_S3GetWithQuery | 5.748 μs | 0.0635 μs | 0.0594 μs | 0.1221 |   3.41 KB |
| Presign_S3GetObject | 6.534 μs | 0.1042 μs | 0.0974 μs | 0.2213 |   6.12 KB |
