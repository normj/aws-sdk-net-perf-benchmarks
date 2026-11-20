```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.18 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 5.771 μs | 0.0134 μs | 0.0119 μs | 0.1297 |   3.73 KB |
| Sign_S3GetWithQuery | 5.227 μs | 0.0166 μs | 0.0155 μs | 0.1373 |   3.98 KB |
| Presign_S3GetObject | 5.859 μs | 0.0162 μs | 0.0151 μs | 0.2365 |   6.63 KB |
