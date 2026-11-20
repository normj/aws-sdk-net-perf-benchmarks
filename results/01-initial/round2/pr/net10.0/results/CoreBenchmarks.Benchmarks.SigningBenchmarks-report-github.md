```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.63 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.091 μs | 0.0192 μs | 0.0170 μs | 0.1068 |   2.98 KB |
| Sign_S3GetWithQuery | 5.439 μs | 0.0417 μs | 0.0390 μs | 0.1221 |   3.41 KB |
| Presign_S3GetObject | 6.190 μs | 0.0354 μs | 0.0296 μs | 0.2213 |   6.12 KB |
