```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,179.46 ns |  20.916 ns |  12.447 ns | 0.1861 |    5456 B |
| DynamoDB_Resolve                 |   862.97 ns |  16.268 ns |  10.760 ns | 0.0584 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    73.49 ns |   3.861 ns |   2.554 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    31.18 ns |   0.711 ns |   0.470 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   147.61 ns |   4.214 ns |   2.787 ns | 0.0099 |     288 B |
| Substring_Suffix                 |    23.36 ns |   0.194 ns |   0.116 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    12.67 ns |   0.180 ns |   0.107 ns |      - |         - |
| ParseArn_AccessPoint             |   432.72 ns |  15.105 ns |   9.991 ns | 0.0372 |    1088 B |
| Interpolate_Url                  |   222.89 ns |   4.556 ns |   3.014 ns | 0.0105 |     312 B |
| InterpolateJson_AuthSchemes      | 2,081.63 ns | 347.812 ns | 230.056 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,997.96 ns | 334.236 ns | 221.076 ns | 0.0401 |    1296 B |
| Partition_KnownRegion            |   147.16 ns |  52.552 ns |  34.760 ns | 0.0121 |     352 B |
