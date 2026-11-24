```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,101.58 ns | 487.560 ns | 290.139 ns | 0.8523 |      - |   31099 B |
| Xml_ListObjectsStructures | 80,305.40 ns | 493.007 ns | 326.094 ns | 1.3089 |      - |   37519 B |
| Xml_DateTimes             | 23,572.90 ns | 186.310 ns | 123.233 ns | 0.5690 |      - |   17980 B |
| Xml_WriteRequestBody      | 21,298.50 ns | 360.683 ns | 214.636 ns | 0.4195 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     91.98 ns |   0.728 ns |   0.433 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,434.81 ns |  16.345 ns |  10.811 ns | 0.4582 | 0.0195 |   12960 B |
