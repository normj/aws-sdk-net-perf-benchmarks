```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.45GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error      | StdDev    | Gen0   | Allocated |
|--------------------------------- |-------------:|-----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,349.674 ns | 13.6578 ns | 7.1433 ns | 0.1908 |    5456 B |
| DynamoDB_Resolve                 |   849.506 ns |  3.8450 ns | 2.5432 ns | 0.0578 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.479 ns |  0.6796 ns | 0.4495 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    29.280 ns |  0.1376 ns | 0.0910 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   126.375 ns |  1.0112 ns | 0.6688 ns | 0.0100 |     288 B |
| Substring_Suffix                 |    21.874 ns |  0.0342 ns | 0.0204 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     3.326 ns |  0.0095 ns | 0.0063 ns |      - |         - |
| ParseArn_AccessPoint             |   328.369 ns |  0.6076 ns | 0.3178 ns | 0.0302 |     880 B |
| Interpolate_Url                  |   215.401 ns |  2.5040 ns | 1.6563 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,478.019 ns |  5.6205 ns | 3.7176 ns | 0.0296 |     984 B |
| Endpoint_WithAttributes          | 1,099.615 ns |  3.6763 ns | 2.1877 ns | 0.0436 |    1296 B |
| Partition_KnownRegion            |   109.238 ns |  3.8019 ns | 1.9885 ns | 0.0121 |     352 B |
