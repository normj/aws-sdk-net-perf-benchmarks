```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,829.77 ns | 928.474 ns | 614.128 ns | 0.1823 |    5456 B |
| DynamoDB_Resolve                 |   830.16 ns |  12.704 ns |   6.645 ns | 0.0586 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    70.93 ns |   0.929 ns |   0.614 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    30.66 ns |   0.336 ns |   0.222 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   151.50 ns |   3.095 ns |   1.842 ns | 0.0098 |     288 B |
| Substring_Suffix                 |    24.02 ns |   0.250 ns |   0.149 ns | 0.0013 |      40 B |
| ParseArn_NotArn                  |    11.68 ns |   0.118 ns |   0.078 ns |      - |         - |
| ParseArn_AccessPoint             |   397.74 ns |   1.831 ns |   1.211 ns | 0.0381 |    1088 B |
| Interpolate_Url                  |   215.29 ns |   4.882 ns |   2.905 ns | 0.0102 |     312 B |
| InterpolateJson_AuthSchemes      | 1,403.57 ns |  21.045 ns |  12.524 ns | 0.0339 |     984 B |
| Endpoint_WithAttributes          | 1,047.44 ns |  14.287 ns |   8.502 ns | 0.0418 |    1296 B |
| Partition_KnownRegion            |    96.80 ns |   2.077 ns |   1.374 ns | 0.0124 |     352 B |
