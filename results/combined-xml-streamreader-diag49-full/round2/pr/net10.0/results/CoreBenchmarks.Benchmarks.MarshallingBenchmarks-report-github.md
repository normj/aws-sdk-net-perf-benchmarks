```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,786.14 ns | 344.356 ns | 227.770 ns | 0.8446 |      - |   31175 B |
| Xml_ListObjectsStructures | 79,929.76 ns | 288.041 ns | 190.522 ns | 1.2821 |      - |   37520 B |
| Xml_DateTimes             | 23,506.06 ns | 204.744 ns | 135.426 ns | 0.5656 |      - |   18008 B |
| Xml_WriteRequestBody      | 20,724.75 ns |  60.643 ns |  36.087 ns | 0.4134 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     97.47 ns |   0.481 ns |   0.286 ns | 0.0102 |      - |     296 B |
| Xml_SmallResponse         |  2,537.90 ns |   9.119 ns |   4.769 ns | 0.5312 | 0.0204 |   15222 B |
