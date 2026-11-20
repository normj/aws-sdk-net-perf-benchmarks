```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,660.06 ns | 114.802 ns |  75.935 ns | 0.1867 |    5456 B |
| DynamoDB_Resolve                 |   902.21 ns |  11.140 ns |   7.368 ns | 0.0585 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    85.06 ns |  21.797 ns |  12.971 ns | 0.0042 |     120 B |
| IsValidHostLabel_Region          |    44.16 ns |  14.675 ns |   9.707 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   137.94 ns |  11.816 ns |   7.816 ns | 0.0102 |     288 B |
| Substring_Suffix                 |    23.60 ns |   0.509 ns |   0.336 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.78 ns |   0.167 ns |   0.111 ns |      - |         - |
| ParseArn_AccessPoint             |   426.83 ns |   4.515 ns |   2.687 ns | 0.0371 |    1088 B |
| Interpolate_Url                  |   222.61 ns |   5.876 ns |   3.887 ns | 0.0107 |     312 B |
| InterpolateJson_AuthSchemes      | 1,768.42 ns | 249.271 ns | 164.878 ns | 0.0303 |     984 B |
| Endpoint_WithAttributes          | 1,272.31 ns | 120.117 ns |  79.450 ns | 0.0421 |    1296 B |
| Partition_KnownRegion            |   112.70 ns |   2.749 ns |   1.636 ns | 0.0124 |     352 B |
