```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error     | StdDev   | Gen0   | Allocated |
|--------------------------------- |------------:|----------:|---------:|-------:|----------:|
| S3_Resolve                       | 4,139.24 ns | 14.205 ns | 8.453 ns | 0.1818 |    5456 B |
| DynamoDB_Resolve                 |   830.66 ns |  2.219 ns | 1.161 ns | 0.0566 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    69.78 ns |  0.638 ns | 0.422 ns | 0.0042 |     120 B |
| IsValidHostLabel_Region          |    28.87 ns |  0.164 ns | 0.098 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   142.33 ns |  0.738 ns | 0.488 ns | 0.0096 |     288 B |
| Substring_Suffix                 |    22.77 ns |  0.176 ns | 0.117 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.64 ns |  0.192 ns | 0.127 ns |      - |         - |
| ParseArn_AccessPoint             |   394.16 ns |  2.839 ns | 1.690 ns | 0.0384 |    1088 B |
| Interpolate_Url                  |   213.43 ns |  1.348 ns | 0.892 ns | 0.0106 |     312 B |
| InterpolateJson_AuthSchemes      | 1,362.84 ns |  1.857 ns | 0.971 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,033.51 ns |  1.958 ns | 1.165 ns | 0.0454 |    1296 B |
| Partition_KnownRegion            |    96.56 ns |  0.363 ns | 0.216 ns | 0.0124 |     352 B |
