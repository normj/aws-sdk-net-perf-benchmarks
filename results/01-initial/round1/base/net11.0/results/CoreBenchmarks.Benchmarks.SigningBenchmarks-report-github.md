```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.96 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.110 μs | 0.0258 μs | 0.0216 μs | 0.1526 |   4.29 KB |
| Sign_S3GetWithQuery | 5.569 μs | 0.1042 μs | 0.2414 μs | 0.1602 |   4.51 KB |
| Presign_S3GetObject | 6.230 μs | 0.0202 μs | 0.0168 μs | 0.2594 |   7.16 KB |
