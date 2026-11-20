```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                           | Mean         | Error      | StdDev     | Gen0   | Allocated |
|--------------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| S3_Resolve                       | 4,175.067 ns | 95.7840 ns | 50.0969 ns | 0.1841 |    5248 B |
| DynamoDB_Resolve                 |   864.410 ns | 15.1222 ns | 10.0024 ns | 0.0564 |    1680 B |
| IsVirtualHostableS3Bucket_NoDots |    22.866 ns |  0.1313 ns |  0.0869 ns |      - |         - |
| IsValidHostLabel_Region          |     8.443 ns |  0.1797 ns |  0.1189 ns |      - |         - |
| IsValidHostLabel_SubDomains      |    43.636 ns |  0.4480 ns |  0.2666 ns |      - |         - |
| Substring_Suffix                 |    19.053 ns |  0.4049 ns |  0.2678 ns | 0.0014 |      40 B |
| ParseArn_NotArn                  |    12.657 ns |  0.6924 ns |  0.4580 ns |      - |         - |
| ParseArn_AccessPoint             |   393.306 ns |  9.5380 ns |  5.6759 ns | 0.0370 |    1088 B |
| Interpolate_Url                  |   221.295 ns |  2.8129 ns |  1.6739 ns | 0.0107 |     312 B |
| InterpolateJson_AuthSchemes      | 1,417.442 ns | 18.4250 ns | 12.1870 ns | 0.0338 |     984 B |
| Endpoint_WithAttributes          | 1,082.262 ns | 58.3823 ns | 38.6163 ns | 0.0420 |    1296 B |
| Partition_KnownRegion            |   100.872 ns |  3.2352 ns |  2.1399 ns | 0.0122 |     352 B |
