```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error       | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|------------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,097.432 ns |  23.7444 ns | 15.7054 ns | 0.1808 |    5456 B |
| DynamoDB_Resolve                 |   811.478 ns |   3.6349 ns |  2.4043 ns | 0.0584 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    72.426 ns |  16.4414 ns |  9.7840 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    29.921 ns |   0.1045 ns |  0.0691 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   142.357 ns |   2.0466 ns |  1.0704 ns | 0.0102 |     288 B |
| Substring_Suffix                 |    21.956 ns |   0.0642 ns |  0.0382 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |     3.347 ns |   0.0026 ns |  0.0013 ns |      - |         - |
| ParseArn_AccessPoint             |   307.678 ns |   1.6303 ns |  1.0783 ns | 0.0306 |     880 B |
| Interpolate_Url                  |   211.958 ns |   0.9183 ns |  0.5465 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,365.066 ns |   4.8318 ns |  2.8753 ns | 0.0328 |     984 B |
| Endpoint_WithAttributes          | 1,066.222 ns | 154.6150 ns | 80.8666 ns | 0.0454 |    1296 B |
| Partition_KnownRegion            |    96.987 ns |   0.4670 ns |  0.2779 ns | 0.0124 |     352 B |
