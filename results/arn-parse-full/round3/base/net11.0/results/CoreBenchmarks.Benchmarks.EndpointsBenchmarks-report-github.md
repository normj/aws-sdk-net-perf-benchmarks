```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,230.26 ns |  32.712 ns |  21.637 ns | 0.1871 |    5456 B |
| DynamoDB_Resolve                 |   835.92 ns |   3.463 ns |   1.811 ns | 0.0570 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.19 ns |   0.288 ns |   0.190 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    29.06 ns |   0.119 ns |   0.071 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   157.17 ns |  42.659 ns |  28.216 ns | 0.0102 |     288 B |
| Substring_Suffix                 |    22.88 ns |   0.106 ns |   0.063 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    10.79 ns |   0.058 ns |   0.038 ns |      - |         - |
| ParseArn_AccessPoint             |   396.36 ns |   3.064 ns |   1.603 ns | 0.0370 |    1088 B |
| Interpolate_Url                  |   214.27 ns |   1.191 ns |   0.788 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,417.31 ns | 199.054 ns | 104.109 ns | 0.0329 |     984 B |
| Endpoint_WithAttributes          | 1,036.61 ns |   3.568 ns |   2.123 ns | 0.0457 |    1296 B |
| Partition_KnownRegion            |    95.70 ns |   0.597 ns |   0.395 ns | 0.0123 |     352 B |
