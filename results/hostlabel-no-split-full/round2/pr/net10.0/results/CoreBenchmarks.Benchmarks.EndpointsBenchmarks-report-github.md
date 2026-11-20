```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error       | StdDev      | Gen0   | Allocated |
|--------------------------------- |-------------:|------------:|------------:|-------:|----------:|
| S3_Resolve                       | 4,438.545 ns |  73.8446 ns |  43.9437 ns | 0.1737 |    5248 B |
| DynamoDB_Resolve                 |   902.299 ns |  12.9705 ns |   8.5792 ns | 0.0582 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    22.588 ns |   2.1705 ns |   1.4357 ns |      - |         - |
| IsValidHostLabel_Region          |     9.619 ns |   0.0892 ns |   0.0590 ns |      - |         - |
| IsValidHostLabel_SubDomains      |    43.553 ns |   0.6071 ns |   0.4016 ns |      - |         - |
| Substring_Suffix                 |    22.645 ns |   0.2260 ns |   0.1345 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    12.957 ns |   0.1692 ns |   0.1007 ns |      - |         - |
| ParseArn_AccessPoint             |   411.610 ns |  15.6415 ns |  10.3459 ns | 0.0378 |    1088 B |
| Interpolate_Url                  |   231.267 ns |   9.2855 ns |   6.1418 ns | 0.0106 |     312 B |
| InterpolateJson_AuthSchemes      | 2,372.585 ns | 166.8459 ns | 110.3582 ns | 0.0337 |     984 B |
| Endpoint_WithAttributes          | 1,081.521 ns |  13.0111 ns |   8.6060 ns | 0.0429 |    1296 B |
| Partition_KnownRegion            |   107.520 ns |   1.4818 ns |   0.8818 ns | 0.0121 |     352 B |
