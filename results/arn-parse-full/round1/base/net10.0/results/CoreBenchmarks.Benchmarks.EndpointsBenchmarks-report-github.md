```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,645.56 ns | 131.602 ns | 68.830 ns | 0.1885 |    5456 B |
| DynamoDB_Resolve                 |   931.14 ns |  24.680 ns | 16.324 ns | 0.0581 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    68.94 ns |   1.369 ns |  0.815 ns | 0.0042 |     120 B |
| IsValidHostLabel_Region          |    29.95 ns |   0.767 ns |  0.457 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   123.83 ns |   0.755 ns |  0.395 ns | 0.0100 |     288 B |
| Substring_Suffix                 |    21.92 ns |   0.082 ns |  0.049 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.14 ns |   0.044 ns |  0.029 ns |      - |         - |
| ParseArn_AccessPoint             |   408.21 ns |  20.463 ns | 13.535 ns | 0.0377 |    1088 B |
| Interpolate_Url                  |   214.36 ns |   1.771 ns |  1.171 ns | 0.0102 |     312 B |
| InterpolateJson_AuthSchemes      | 1,496.31 ns |  10.043 ns |  6.643 ns | 0.0299 |     984 B |
| Endpoint_WithAttributes          | 1,114.97 ns |   8.023 ns |  4.775 ns | 0.0449 |    1296 B |
| Partition_KnownRegion            |   111.93 ns |   0.298 ns |  0.177 ns | 0.0121 |     352 B |
