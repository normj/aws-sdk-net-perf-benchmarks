```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,343.7 ns | 146.39 ns |  87.12 ns | 0.8523 |      - |   31099 B |
| Xml_ListObjectsStructures | 80,475.0 ns | 284.31 ns | 169.19 ns | 1.2821 |      - |   37519 B |
| Xml_DateTimes             | 23,593.8 ns | 110.59 ns |  57.84 ns | 0.5656 |      - |   17980 B |
| Xml_WriteRequestBody      | 20,839.4 ns |  78.16 ns |  46.51 ns | 0.4156 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    104.0 ns |   1.27 ns |   0.76 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,541.3 ns |  25.99 ns |  17.19 ns | 0.4561 | 0.0198 |   12960 B |
