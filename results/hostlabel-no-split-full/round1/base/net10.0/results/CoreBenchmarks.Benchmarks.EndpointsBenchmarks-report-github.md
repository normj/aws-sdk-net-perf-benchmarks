```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,657.98 ns | 119.179 ns | 78.829 ns | 0.1768 |    5456 B |
| DynamoDB_Resolve                 |   919.78 ns |  18.358 ns | 10.924 ns | 0.0584 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    72.45 ns |   1.440 ns |  0.857 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    31.09 ns |   0.886 ns |  0.586 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   141.53 ns |   4.274 ns |  2.827 ns | 0.0101 |     288 B |
| Substring_Suffix                 |    20.02 ns |   0.636 ns |  0.421 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.98 ns |   0.146 ns |  0.097 ns |      - |         - |
| ParseArn_AccessPoint             |   461.09 ns |  10.891 ns |  5.696 ns | 0.0379 |    1088 B |
| Interpolate_Url                  |   232.95 ns |   4.685 ns |  3.099 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,543.60 ns |  22.326 ns | 14.767 ns | 0.0308 |     984 B |
| Endpoint_WithAttributes          | 1,137.57 ns |  28.580 ns | 18.904 ns | 0.0456 |    1296 B |
| Partition_KnownRegion            |   112.53 ns |   2.271 ns |  1.188 ns | 0.0123 |     352 B |
