```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.45 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Median   | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|---------:|-------:|----------:|
| Sign_JsonPost       | 6.396 μs | 0.1267 μs | 0.1123 μs | 6.397 μs | 0.1526 |   4.29 KB |
| Sign_S3GetWithQuery | 5.635 μs | 0.0596 μs | 0.1149 μs | 5.588 μs | 0.1602 |   4.51 KB |
| Presign_S3GetObject | 6.354 μs | 0.0363 μs | 0.0322 μs | 6.356 μs | 0.2594 |   7.16 KB |
