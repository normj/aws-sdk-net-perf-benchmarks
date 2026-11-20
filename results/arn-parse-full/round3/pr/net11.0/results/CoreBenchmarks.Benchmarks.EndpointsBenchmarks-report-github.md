```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,122.670 ns | 33.0320 ns | 17.2764 ns | 0.1833 |    5456 B |
| DynamoDB_Resolve                 |   808.434 ns |  5.6645 ns |  3.7467 ns | 0.0582 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    66.273 ns |  0.3554 ns |  0.2351 ns | 0.0042 |     120 B |
| IsValidHostLabel_Region          |    28.808 ns |  0.0934 ns |  0.0488 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   156.094 ns | 46.1571 ns | 27.4673 ns | 0.0102 |     288 B |
| Substring_Suffix                 |    22.046 ns |  0.0767 ns |  0.0457 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     2.822 ns |  0.0138 ns |  0.0091 ns |      - |         - |
| ParseArn_AccessPoint             |   308.171 ns |  4.5765 ns |  2.7234 ns | 0.0306 |     880 B |
| Interpolate_Url                  |   212.279 ns |  2.6369 ns |  1.7442 ns | 0.0110 |     312 B |
| InterpolateJson_AuthSchemes      | 1,365.706 ns |  0.8773 ns |  0.4588 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,032.584 ns |  4.7602 ns |  3.1486 ns | 0.0452 |    1296 B |
| Partition_KnownRegion            |    98.886 ns |  0.4161 ns |  0.2753 ns | 0.0122 |     352 B |
