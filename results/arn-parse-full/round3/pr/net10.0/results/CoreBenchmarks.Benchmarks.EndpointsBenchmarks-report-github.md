```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error     | StdDev    | Gen0   | Allocated |
|--------------------------------- |-------------:|----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,374.772 ns | 6.4401 ns | 3.8324 ns | 0.1923 |    5456 B |
| DynamoDB_Resolve                 |   858.081 ns | 4.7500 ns | 2.8266 ns | 0.0584 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    69.428 ns | 0.6918 ns | 0.4576 ns | 0.0042 |     120 B |
| IsValidHostLabel_Region          |    29.527 ns | 0.2077 ns | 0.1374 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   131.005 ns | 2.4986 ns | 1.3068 ns | 0.0099 |     288 B |
| Substring_Suffix                 |    17.994 ns | 0.1041 ns | 0.0619 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     3.577 ns | 0.0050 ns | 0.0033 ns |      - |         - |
| ParseArn_AccessPoint             |   320.395 ns | 2.1454 ns | 1.4191 ns | 0.0298 |     880 B |
| Interpolate_Url                  |   215.354 ns | 0.6331 ns | 0.3311 ns | 0.0104 |     312 B |
| InterpolateJson_AuthSchemes      | 1,456.347 ns | 6.1081 ns | 3.6348 ns | 0.0291 |     984 B |
| Endpoint_WithAttributes          | 1,085.302 ns | 4.4791 ns | 2.6654 ns | 0.0431 |    1296 B |
| Partition_KnownRegion            |   104.080 ns | 0.2649 ns | 0.1576 ns | 0.0125 |     352 B |
