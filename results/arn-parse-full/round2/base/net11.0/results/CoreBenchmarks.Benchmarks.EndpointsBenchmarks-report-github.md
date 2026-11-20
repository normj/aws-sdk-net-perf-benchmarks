```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error     | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,112.06 ns | 31.081 ns | 18.496 ns | 0.1801 |    5456 B |
| DynamoDB_Resolve                 |   831.71 ns |  5.635 ns |  2.947 ns | 0.0565 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    69.28 ns |  2.573 ns |  1.702 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    28.81 ns |  0.112 ns |  0.067 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   138.65 ns |  1.114 ns |  0.737 ns | 0.0099 |     288 B |
| Substring_Suffix                 |    22.87 ns |  0.119 ns |  0.062 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    10.80 ns |  0.063 ns |  0.038 ns |      - |         - |
| ParseArn_AccessPoint             |   390.83 ns | 14.983 ns |  9.910 ns | 0.0381 |    1088 B |
| Interpolate_Url                  |   243.80 ns | 66.059 ns | 43.694 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,364.07 ns |  4.114 ns |  2.152 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,032.74 ns |  6.012 ns |  3.577 ns | 0.0454 |    1296 B |
| Partition_KnownRegion            |    96.64 ns |  0.357 ns |  0.187 ns | 0.0125 |     352 B |
