```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,355.5 ns | 899.82 ns | 535.47 ns | 0.8562 |      - |   31099 B |
| Xml_ListObjectsStructures | 80,790.6 ns | 343.82 ns | 204.60 ns | 1.2887 |      - |   37519 B |
| Xml_DateTimes             | 23,373.1 ns | 205.46 ns | 135.90 ns | 0.5673 |      - |   17980 B |
| Xml_WriteRequestBody      | 20,837.2 ns | 137.26 ns |  90.79 ns | 0.4178 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    104.2 ns |   0.66 ns |   0.39 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,392.4 ns |  13.77 ns |   9.11 ns | 0.4522 | 0.0192 |   12960 B |
