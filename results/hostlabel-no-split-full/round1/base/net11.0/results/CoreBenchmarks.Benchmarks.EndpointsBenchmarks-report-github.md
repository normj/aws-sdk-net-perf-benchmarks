```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,330.97 ns |  70.556 ns |  46.668 ns | 0.1925 |    5456 B |
| DynamoDB_Resolve                 |   888.19 ns |  42.918 ns |  25.540 ns | 0.0578 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    73.25 ns |   3.908 ns |   2.326 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    30.82 ns |   0.435 ns |   0.259 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   156.54 ns |   3.442 ns |   2.277 ns | 0.0099 |     288 B |
| Substring_Suffix                 |    24.13 ns |   0.297 ns |   0.197 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.25 ns |   0.243 ns |   0.160 ns |      - |         - |
| ParseArn_AccessPoint             |   410.15 ns |   2.549 ns |   1.333 ns | 0.0376 |    1088 B |
| Interpolate_Url                  |   219.74 ns |   5.186 ns |   3.430 ns | 0.0104 |     312 B |
| InterpolateJson_AuthSchemes      | 1,457.17 ns |  27.109 ns |  17.931 ns | 0.0344 |     984 B |
| Endpoint_WithAttributes          | 1,476.14 ns | 393.906 ns | 260.544 ns | 0.0441 |    1296 B |
| Partition_KnownRegion            |   102.76 ns |   2.012 ns |   1.331 ns | 0.0125 |     352 B |
