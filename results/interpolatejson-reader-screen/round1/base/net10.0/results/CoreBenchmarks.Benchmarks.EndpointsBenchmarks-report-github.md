```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,914.53 ns | 898.266 ns | 320.330 ns | 0.1764 |    5456 B |
| DynamoDB_Resolve                 |   887.31 ns |  10.100 ns |   2.623 ns | 0.0564 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.57 ns |   1.905 ns |   0.679 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    29.39 ns |   0.245 ns |   0.087 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   125.18 ns |   0.933 ns |   0.333 ns | 0.0100 |     288 B |
| Substring_Suffix                 |    18.05 ns |   0.299 ns |   0.107 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.18 ns |   0.174 ns |   0.062 ns |      - |         - |
| ParseArn_AccessPoint             |   410.20 ns |  15.297 ns |   5.455 ns | 0.0380 |    1088 B |
| Interpolate_Url                  |   215.18 ns |   2.544 ns |   0.907 ns | 0.0104 |     312 B |
| InterpolateJson_AuthSchemes      | 1,462.72 ns |   8.326 ns |   2.969 ns | 0.0292 |     984 B |
| Endpoint_WithAttributes          | 1,079.29 ns |  12.644 ns |   4.509 ns | 0.0432 |    1296 B |
| Partition_KnownRegion            |   109.42 ns |   1.166 ns |   0.303 ns | 0.0122 |     352 B |
