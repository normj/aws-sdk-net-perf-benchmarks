```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,783.03 ns | 502.231 ns | 332.195 ns | 0.8484 |      - |   31099 B |
| Xml_ListObjectsStructures | 80,497.07 ns | 473.468 ns | 313.170 ns | 1.2887 |      - |   37519 B |
| Xml_DateTimes             | 23,474.72 ns | 189.070 ns | 125.058 ns | 0.5614 |      - |   17980 B |
| Xml_WriteRequestBody      | 20,854.25 ns |  36.359 ns |  21.636 ns | 0.4172 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     88.76 ns |   0.448 ns |   0.267 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,385.90 ns |  13.336 ns |   7.936 ns | 0.4572 | 0.0190 |   12960 B |
