```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,442.07 ns |  35.208 ns |  23.288 ns | 0.1776 |    5456 B |
| DynamoDB_Resolve                 |   863.87 ns |   5.251 ns |   2.747 ns | 0.0560 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    71.07 ns |   0.418 ns |   0.249 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    30.43 ns |   0.578 ns |   0.382 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   129.40 ns |   1.055 ns |   0.698 ns | 0.0098 |     288 B |
| Substring_Suffix                 |    25.24 ns |   2.748 ns |   1.818 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.71 ns |   0.078 ns |   0.046 ns |      - |         - |
| ParseArn_AccessPoint             |   405.19 ns |  10.938 ns |   7.234 ns | 0.0370 |    1088 B |
| Interpolate_Url                  |   222.88 ns |   3.741 ns |   2.475 ns | 0.0102 |     312 B |
| InterpolateJson_AuthSchemes      | 1,652.71 ns | 186.914 ns | 123.632 ns | 0.0304 |     984 B |
| Endpoint_WithAttributes          | 1,127.32 ns |  20.167 ns |  12.001 ns | 0.0447 |    1296 B |
| Partition_KnownRegion            |   107.79 ns |   1.775 ns |   1.174 ns | 0.0122 |     352 B |
