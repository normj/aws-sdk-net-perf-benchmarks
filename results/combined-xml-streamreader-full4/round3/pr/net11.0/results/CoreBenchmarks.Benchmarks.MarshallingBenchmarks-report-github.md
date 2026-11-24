```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,520.47 ns | 441.904 ns | 262.970 ns | 0.8408 |   31149 B |
| Xml_ListObjectsStructures | 78,687.27 ns | 271.573 ns | 161.609 ns | 1.2563 |   37492 B |
| Xml_DateTimes             | 23,109.44 ns | 112.195 ns |  66.766 ns | 0.5556 |   18028 B |
| Xml_WriteRequestBody      | 19,759.41 ns |  94.681 ns |  49.520 ns | 0.4753 |   13880 B |
| Xml_HeaderOnlyResponse    |     93.65 ns |   0.835 ns |   0.552 ns | 0.0107 |     304 B |
| Xml_SmallResponse         |  2,338.24 ns |  23.755 ns |  14.136 ns | 0.4534 |   12968 B |
