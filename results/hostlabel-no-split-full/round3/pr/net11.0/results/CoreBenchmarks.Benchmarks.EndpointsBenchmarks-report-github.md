```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,029.213 ns | 48.5890 ns | 32.1386 ns | 0.1761 |    5248 B |
| DynamoDB_Resolve                 |   823.199 ns |  6.1976 ns |  3.6881 ns | 0.0589 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    22.731 ns |  0.0886 ns |  0.0464 ns |      - |         - |
| IsValidHostLabel_Region          |     9.555 ns |  0.0600 ns |  0.0397 ns |      - |         - |
| IsValidHostLabel_SubDomains      |    39.032 ns |  0.1303 ns |  0.0862 ns |      - |         - |
| Substring_Suffix                 |    22.877 ns |  0.1395 ns |  0.0923 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.467 ns |  0.1196 ns |  0.0712 ns |      - |         - |
| ParseArn_AccessPoint             |   376.923 ns |  4.0247 ns |  2.3950 ns | 0.0374 |    1088 B |
| Interpolate_Url                  |   214.000 ns |  1.9190 ns |  1.2693 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,367.446 ns |  9.9051 ns |  6.5516 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,013.202 ns |  3.2495 ns |  2.1493 ns | 0.0445 |    1296 B |
| Partition_KnownRegion            |   110.335 ns |  0.4216 ns |  0.2509 ns | 0.0124 |     352 B |
