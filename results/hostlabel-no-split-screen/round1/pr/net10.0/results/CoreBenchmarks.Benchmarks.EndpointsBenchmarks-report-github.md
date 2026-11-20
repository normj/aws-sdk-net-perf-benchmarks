```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                           | Mean      | Error     | StdDev    | Allocated |
|--------------------------------- |----------:|----------:|----------:|----------:|
| IsVirtualHostableS3Bucket_NoDots | 21.688 ns | 0.4963 ns | 0.1289 ns |         - |
| IsValidHostLabel_Region          |  9.702 ns | 0.1961 ns | 0.0699 ns |         - |
| IsValidHostLabel_SubDomains      | 43.069 ns | 1.1861 ns | 0.3080 ns |         - |
