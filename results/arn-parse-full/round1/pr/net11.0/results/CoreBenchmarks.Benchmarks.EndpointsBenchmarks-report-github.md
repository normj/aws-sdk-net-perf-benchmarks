```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error       | StdDev      | Gen0   | Allocated |
|--------------------------------- |-------------:|------------:|------------:|-------:|----------:|
| S3_Resolve                       | 4,186.501 ns |  83.2240 ns |  49.5253 ns | 0.1820 |    5456 B |
| DynamoDB_Resolve                 |   958.607 ns | 313.1134 ns | 207.1051 ns | 0.0594 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    67.890 ns |   0.5243 ns |   0.3468 ns | 0.0041 |     120 B |
| IsValidHostLabel_Region          |    28.526 ns |   0.1303 ns |   0.0862 ns | 0.0031 |      88 B |
| IsValidHostLabel_SubDomains      |   138.338 ns |   1.0689 ns |   0.7070 ns | 0.0098 |     288 B |
| Substring_Suffix                 |    22.121 ns |   0.1225 ns |   0.0811 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     3.088 ns |   0.0177 ns |   0.0092 ns |      - |         - |
| ParseArn_AccessPoint             |   310.378 ns |   2.9552 ns |   1.9547 ns | 0.0310 |     880 B |
| Interpolate_Url                  |   218.811 ns |   2.0090 ns |   1.1955 ns | 0.0110 |     312 B |
| InterpolateJson_AuthSchemes      | 1,403.758 ns |  34.5334 ns |  22.8417 ns | 0.0334 |     984 B |
| Endpoint_WithAttributes          | 1,093.697 ns |  21.5054 ns |  14.2245 ns | 0.0424 |    1296 B |
| Partition_KnownRegion            |   115.729 ns |   9.1835 ns |   4.8032 ns | 0.0124 |     352 B |
