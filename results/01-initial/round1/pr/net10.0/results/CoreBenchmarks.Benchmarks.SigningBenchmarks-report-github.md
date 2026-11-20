```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.91 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4


```
| Method              | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Sign_JsonPost       | 6.007 μs | 0.0236 μs | 0.0221 μs | 0.1068 |   2.98 KB |
| Sign_S3GetWithQuery | 5.386 μs | 0.0299 μs | 0.0265 μs | 0.1221 |   3.41 KB |
| Presign_S3GetObject | 6.159 μs | 0.0218 μs | 0.0193 μs | 0.2213 |   6.12 KB |
