```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error     | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,499.04 ns | 21.079 ns | 12.544 ns | 0.1802 |    5456 B |
| DynamoDB_Resolve                 |   860.80 ns |  4.221 ns |  2.512 ns | 0.0589 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.50 ns |  0.377 ns |  0.249 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    33.78 ns | 10.914 ns |  7.219 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   129.05 ns |  1.764 ns |  1.050 ns | 0.0097 |     288 B |
| Substring_Suffix                 |    22.90 ns |  0.180 ns |  0.094 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.21 ns |  0.156 ns |  0.093 ns |      - |         - |
| ParseArn_AccessPoint             |   400.35 ns |  2.408 ns |  1.593 ns | 0.0382 |    1088 B |
| Interpolate_Url                  |   224.29 ns |  2.838 ns |  1.689 ns | 0.0106 |     312 B |
| InterpolateJson_AuthSchemes      | 1,533.92 ns |  8.183 ns |  4.869 ns | 0.0308 |     984 B |
| Endpoint_WithAttributes          | 1,104.58 ns |  8.134 ns |  5.380 ns | 0.0439 |    1296 B |
| Partition_KnownRegion            |   119.52 ns | 31.508 ns | 20.840 ns | 0.0122 |     352 B |
