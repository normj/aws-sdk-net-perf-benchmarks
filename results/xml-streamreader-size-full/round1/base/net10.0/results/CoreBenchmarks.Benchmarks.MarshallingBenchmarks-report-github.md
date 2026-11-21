```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,453.6 ns |   426.48 ns |   282.09 ns | 0.8641 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 84,878.6 ns | 7,729.33 ns | 5,112.47 ns | 1.2821 |      - |  36.63 KB |
| Xml_DateTimes             | 24,514.5 ns |   808.20 ns |   480.95 ns | 0.5943 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,940.5 ns |   177.11 ns |    92.63 ns | 0.4161 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    279.7 ns |     7.68 ns |     4.57 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,535.9 ns |    25.04 ns |    14.90 ns | 0.5297 |      - |  14.83 KB |
