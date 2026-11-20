```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method               | Mean         | Error        | StdDev     | Gen0   | Allocated |
|--------------------- |-------------:|-------------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike  | 77,461.77 ns | 2,722.277 ns | 970.790 ns | 0.9146 |   31134 B |
| Xml_DateTimes        | 25,579.04 ns |   508.668 ns | 181.396 ns | 0.6117 |   17968 B |
| Json_DateTimeStrings | 16,650.45 ns |   665.386 ns | 237.283 ns | 0.2014 |    6040 B |
| Json_Strings         |  3,741.91 ns |   230.883 ns |  82.335 ns | 0.2666 |    7848 B |
| Format_ISO8601       |    156.12 ns |     6.634 ns |   2.366 ns | 0.0025 |      72 B |
| Format_ISO8601NoMs   |     81.24 ns |     3.018 ns |   1.076 ns | 0.0023 |      64 B |
