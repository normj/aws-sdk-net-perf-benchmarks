```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.72 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,057.64 ns | 285.737 ns | 188.998 ns | 0.8484 |   31108 B |
| Xml_ListObjectsStructures | 79,952.49 ns | 550.165 ns | 327.395 ns | 1.2953 |   37527 B |
| Xml_DateTimes             | 23,505.13 ns | 118.563 ns |  78.422 ns | 0.5648 |   17987 B |
| Xml_WriteRequestBody      | 20,726.16 ns |  32.956 ns |  17.237 ns | 0.4195 |   13880 B |
| Xml_HeaderOnlyResponse    |     92.76 ns |   1.456 ns |   0.867 ns | 0.0108 |     304 B |
| Xml_SmallResponse         |  2,429.03 ns |  22.054 ns |  14.587 ns | 0.4590 |   12968 B |
