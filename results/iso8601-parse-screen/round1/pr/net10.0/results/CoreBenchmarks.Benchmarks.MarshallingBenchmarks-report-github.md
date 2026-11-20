```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method               | Mean         | Error        | StdDev     | Gen0   | Allocated |
|--------------------- |-------------:|-------------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike  | 61,093.49 ns | 1,906.937 ns | 680.032 ns | 0.9766 |   31134 B |
| Xml_DateTimes        | 12,683.86 ns |   624.631 ns | 222.749 ns | 0.6329 |   18012 B |
| Json_DateTimeStrings |  4,374.39 ns |   371.251 ns | 132.392 ns | 0.2078 |    6040 B |
| Json_Strings         |  3,665.81 ns |    84.380 ns |  30.091 ns | 0.2731 |    7848 B |
| Format_ISO8601       |    147.98 ns |     0.653 ns |   0.170 ns | 0.0024 |      72 B |
| Format_ISO8601NoMs   |     79.12 ns |     1.357 ns |   0.484 ns | 0.0022 |      64 B |
