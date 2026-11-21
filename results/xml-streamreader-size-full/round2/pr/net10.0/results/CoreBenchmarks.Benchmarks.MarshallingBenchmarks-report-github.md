```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,747.8 ns | 434.10 ns | 227.05 ns | 0.8562 |      - |   31134 B |
| Xml_ListObjectsStructures | 80,322.0 ns | 319.62 ns | 190.20 ns | 1.2887 |      - |   37512 B |
| Xml_DateTimes             | 23,919.1 ns | 185.63 ns | 122.78 ns | 0.5725 |      - |   17968 B |
| Xml_WriteRequestBody      | 20,662.7 ns | 102.60 ns |  61.06 ns | 0.4117 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    163.1 ns |   0.66 ns |   0.39 ns | 0.0307 |      - |     880 B |
| Xml_SmallResponse         |  2,439.1 ns |  18.11 ns |  11.98 ns | 0.4565 | 0.0194 |   12939 B |
