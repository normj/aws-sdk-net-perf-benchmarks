```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,354.031 ns | 54.8772 ns | 36.2978 ns | 0.1723 |    5248 B |
| DynamoDB_Resolve                 |   851.877 ns |  1.3088 ns |  0.7789 ns | 0.0579 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    21.265 ns |  0.0251 ns |  0.0166 ns |      - |         - |
| IsValidHostLabel_Region          |     8.304 ns |  0.0815 ns |  0.0485 ns |      - |         - |
| IsValidHostLabel_SubDomains      |    42.758 ns |  1.6470 ns |  1.0894 ns |      - |         - |
| Substring_Suffix                 |    22.610 ns |  0.1261 ns |  0.0750 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    10.980 ns |  0.0842 ns |  0.0557 ns |      - |         - |
| ParseArn_AccessPoint             |   399.889 ns |  2.5834 ns |  1.7088 ns | 0.0371 |    1088 B |
| Interpolate_Url                  |   219.044 ns |  0.5081 ns |  0.2657 ns | 0.0105 |     312 B |
| InterpolateJson_AuthSchemes      | 1,474.808 ns |  3.4828 ns |  2.0726 ns | 0.0299 |     984 B |
| Endpoint_WithAttributes          | 1,117.889 ns |  7.0033 ns |  4.6323 ns | 0.0445 |    1296 B |
| Partition_KnownRegion            |   107.016 ns |  1.0667 ns |  0.7055 ns | 0.0124 |     352 B |
