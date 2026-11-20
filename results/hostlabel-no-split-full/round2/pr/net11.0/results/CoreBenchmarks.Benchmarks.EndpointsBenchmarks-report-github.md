```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error       | StdDev      | Gen0   | Allocated |
|--------------------------------- |-------------:|------------:|------------:|-------:|----------:|
| S3_Resolve                       | 4,105.972 ns |  37.4888 ns |  22.3090 ns | 0.1844 |    5248 B |
| DynamoDB_Resolve                 |   846.693 ns |  13.4482 ns |   8.8951 ns | 0.0574 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    23.104 ns |   0.2262 ns |   0.1183 ns |      - |         - |
| IsValidHostLabel_Region          |     9.639 ns |   0.0468 ns |   0.0279 ns |      - |         - |
| IsValidHostLabel_SubDomains      |    43.213 ns |   0.7998 ns |   0.4183 ns |      - |         - |
| Substring_Suffix                 |    23.782 ns |   0.8142 ns |   0.5386 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.458 ns |   0.1861 ns |   0.1231 ns |      - |         - |
| ParseArn_AccessPoint             |   383.926 ns |   3.8761 ns |   2.5638 ns | 0.0383 |    1088 B |
| Interpolate_Url                  |   221.461 ns |   3.4118 ns |   2.2567 ns | 0.0109 |     312 B |
| InterpolateJson_AuthSchemes      | 1,825.113 ns | 338.8858 ns | 224.1520 ns | 0.0335 |     984 B |
| Endpoint_WithAttributes          | 1,506.427 ns | 389.4310 ns | 257.5845 ns | 0.0444 |    1296 B |
| Partition_KnownRegion            |   178.101 ns |  34.5368 ns |  22.8439 ns | 0.0121 |     352 B |
