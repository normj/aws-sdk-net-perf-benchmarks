```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                           | Mean        | Error     | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|----------:|----------:|-------:|----------:|
| S3_Resolve                       | 3,817.69 ns | 91.869 ns | 23.858 ns | 0.1669 |    4840 B |
| DynamoDB_Resolve                 |   867.40 ns |  5.220 ns |  1.356 ns | 0.0590 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    69.00 ns |  2.052 ns |  0.533 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    29.45 ns |  0.211 ns |  0.075 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   127.64 ns |  2.410 ns |  0.860 ns | 0.0097 |     288 B |
| Substring_Suffix                 |    22.05 ns |  0.426 ns |  0.111 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    10.99 ns |  0.102 ns |  0.036 ns |      - |         - |
| ParseArn_AccessPoint             |   400.25 ns |  6.134 ns |  2.188 ns | 0.0384 |    1088 B |
| Interpolate_Url                  |   218.09 ns |  5.533 ns |  1.973 ns | 0.0104 |     312 B |
| InterpolateJson_AuthSchemes      |   865.79 ns |  4.827 ns |  1.254 ns | 0.0104 |     368 B |
| Endpoint_WithAttributes          | 1,087.69 ns | 11.812 ns |  3.067 ns | 0.0434 |    1296 B |
| Partition_KnownRegion            |   131.45 ns | 82.964 ns | 29.586 ns | 0.0122 |     352 B |
