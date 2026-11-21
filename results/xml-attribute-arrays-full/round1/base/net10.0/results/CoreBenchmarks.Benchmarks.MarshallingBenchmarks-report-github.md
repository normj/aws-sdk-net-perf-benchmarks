```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,751.7 ns | 353.67 ns | 184.97 ns | 0.8681 |   30.4 KB |
| Xml_ListObjectsStructures | 80,516.2 ns | 459.58 ns | 303.98 ns | 1.2821 |  36.63 KB |
| Xml_DateTimes             | 24,137.6 ns | 764.28 ns | 505.52 ns | 0.5725 |  17.55 KB |
| Xml_WriteRequestBody      | 21,880.7 ns |  80.05 ns |  47.64 ns | 0.4371 |  13.55 KB |
| Xml_HeaderOnlyResponse    |    374.5 ns | 103.80 ns |  68.66 ns | 0.1259 |   3.48 KB |
| Xml_SmallResponse         |  2,706.6 ns | 384.27 ns | 254.17 ns | 0.5309 |  14.83 KB |
