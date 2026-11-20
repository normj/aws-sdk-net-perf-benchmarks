```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error       | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|------------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,427.923 ns | 109.8572 ns | 57.4575 ns | 0.1768 |    5456 B |
| DynamoDB_Resolve                 |   848.016 ns |   0.5322 ns |  0.2783 ns | 0.0577 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.392 ns |   0.2973 ns |  0.1966 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    29.558 ns |   0.2520 ns |  0.1500 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   127.622 ns |   1.0163 ns |  0.6048 ns | 0.0097 |     288 B |
| Substring_Suffix                 |    18.339 ns |   0.4019 ns |  0.2392 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     3.047 ns |   0.0093 ns |  0.0049 ns |      - |         - |
| ParseArn_AccessPoint             |   322.711 ns |   1.1539 ns |  0.6867 ns | 0.0309 |     880 B |
| Interpolate_Url                  |   216.423 ns |   2.0513 ns |  1.2207 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,463.412 ns |   5.4774 ns |  3.2595 ns | 0.0293 |     984 B |
| Endpoint_WithAttributes          | 1,114.779 ns | 157.2654 ns | 82.2529 ns | 0.0431 |    1296 B |
| Partition_KnownRegion            |   103.580 ns |   0.1816 ns |  0.1081 ns | 0.0124 |     352 B |
