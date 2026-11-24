```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,491.19 ns | 404.342 ns | 240.617 ns | 0.8296 |   31107 B |
| Xml_ListObjectsStructures | 77,382.81 ns | 593.493 ns | 392.559 ns | 1.2690 |   37449 B |
| Xml_DateTimes             | 23,182.72 ns | 118.720 ns |  62.093 ns | 0.5539 |   17987 B |
| Xml_WriteRequestBody      | 19,603.50 ns |  82.131 ns |  54.325 ns | 0.4693 |   13880 B |
| Xml_HeaderOnlyResponse    |     87.55 ns |   0.712 ns |   0.471 ns | 0.0102 |     296 B |
| Xml_SmallResponse         |  2,450.49 ns |  28.457 ns |  18.822 ns | 0.5320 |   15160 B |
