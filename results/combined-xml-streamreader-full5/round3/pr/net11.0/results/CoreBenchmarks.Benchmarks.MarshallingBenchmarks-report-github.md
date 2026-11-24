```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,819.45 ns | 386.550 ns | 230.030 ns | 0.8484 |      - |   31141 B |
| Xml_ListObjectsStructures | 79,140.63 ns | 801.740 ns | 530.302 ns | 1.2626 |      - |   37483 B |
| Xml_DateTimes             | 23,869.35 ns | 112.004 ns |  66.652 ns | 0.5622 |      - |   18020 B |
| Xml_WriteRequestBody      | 20,165.57 ns | 268.917 ns | 177.872 ns | 0.4802 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     91.32 ns |   1.501 ns |   0.893 ns | 0.0101 |      - |     296 B |
| Xml_SmallResponse         |  2,327.56 ns |  12.823 ns |   6.707 ns | 0.4570 | 0.0187 |   12960 B |
