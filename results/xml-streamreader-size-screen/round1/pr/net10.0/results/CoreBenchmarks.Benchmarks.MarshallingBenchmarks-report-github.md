```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,009.3 ns |   555.46 ns | 198.08 ns | 0.8762 |      - |   31134 B |
| Xml_ListObjectsStructures | 80,652.4 ns | 1,216.61 ns | 433.86 ns | 1.2821 |      - |   37512 B |
| Xml_DateTimes             | 24,032.6 ns |   728.85 ns | 259.91 ns | 0.5769 |      - |   17968 B |
| Xml_WriteRequestBody      | 20,925.6 ns |   513.04 ns | 182.96 ns | 0.4139 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    165.5 ns |     3.95 ns |   1.41 ns | 0.0309 |      - |     880 B |
| Xml_SmallResponse         |  2,439.8 ns |    21.86 ns |   5.68 ns | 0.4561 | 0.0194 |   12939 B |
