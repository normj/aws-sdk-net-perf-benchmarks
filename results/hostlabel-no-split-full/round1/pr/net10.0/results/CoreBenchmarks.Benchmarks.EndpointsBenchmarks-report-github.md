```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,578.67 ns |  99.507 ns | 59.215 ns | 0.1809 |    5248 B |
| DynamoDB_Resolve                 |   915.63 ns |  47.321 ns | 28.160 ns | 0.0566 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    43.96 ns |  15.865 ns | 10.493 ns |      - |         - |
| IsValidHostLabel_Region          |    11.65 ns |   1.775 ns |  1.174 ns |      - |         - |
| IsValidHostLabel_SubDomains      |   108.17 ns |  44.826 ns | 29.650 ns |      - |         - |
| Substring_Suffix                 |    39.34 ns |   7.880 ns |  5.212 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    19.85 ns |   3.368 ns |  2.228 ns |      - |         - |
| ParseArn_AccessPoint             |   780.46 ns | 162.996 ns | 96.996 ns | 0.0375 |    1088 B |
| Interpolate_Url                  |   333.38 ns |  96.740 ns | 63.988 ns | 0.0100 |     312 B |
| InterpolateJson_AuthSchemes      | 1,605.77 ns |  86.495 ns | 57.211 ns | 0.0318 |     984 B |
| Endpoint_WithAttributes          | 1,150.28 ns |  23.769 ns | 15.721 ns | 0.0447 |    1296 B |
| Partition_KnownRegion            |   110.66 ns |   2.346 ns |  1.552 ns | 0.0122 |     352 B |
