```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean        | Error      | StdDev    | Gen0   | Allocated |
|--------------------------------- |------------:|-----------:|----------:|-------:|----------:|
| S3_Resolve                       | 4,425.47 ns |  24.708 ns | 14.703 ns | 0.1854 |    5456 B |
| DynamoDB_Resolve                 |   861.46 ns |   5.232 ns |  2.737 ns | 0.0582 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    67.11 ns |   0.432 ns |  0.257 ns | 0.0040 |     120 B |
| IsValidHostLabel_Region          |    29.33 ns |   0.116 ns |  0.077 ns | 0.0030 |      88 B |
| IsValidHostLabel_SubDomains      |   126.64 ns |   3.161 ns |  1.653 ns | 0.0100 |     288 B |
| Substring_Suffix                 |    21.90 ns |   0.117 ns |  0.077 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    11.32 ns |   0.078 ns |  0.046 ns |      - |         - |
| ParseArn_AccessPoint             |   441.46 ns | 129.289 ns | 76.938 ns | 0.0376 |    1088 B |
| Interpolate_Url                  |   215.09 ns |   1.837 ns |  1.215 ns | 0.0103 |     312 B |
| InterpolateJson_AuthSchemes      | 1,457.63 ns |   7.434 ns |  3.888 ns | 0.0293 |     984 B |
| Endpoint_WithAttributes          | 1,099.27 ns |   8.218 ns |  5.436 ns | 0.0439 |    1296 B |
| Partition_KnownRegion            |   106.03 ns |   0.670 ns |  0.443 ns | 0.0122 |     352 B |
