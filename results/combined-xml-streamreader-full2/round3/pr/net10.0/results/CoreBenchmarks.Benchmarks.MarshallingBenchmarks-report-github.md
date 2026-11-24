```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 76,909.8 ns | 812.97 ns | 537.73 ns | 0.9191 |      - |   31133 B |
| Xml_ListObjectsStructures | 85,074.3 ns | 361.70 ns | 215.24 ns | 1.0190 |      - |   37520 B |
| Xml_DateTimes             | 24,500.5 ns | 198.99 ns | 104.07 ns | 0.5896 |      - |   18011 B |
| Xml_WriteRequestBody      | 20,997.9 ns | 124.34 ns |  73.99 ns | 0.4161 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    103.8 ns |   0.67 ns |   0.40 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,568.2 ns |  40.97 ns |  27.10 ns | 0.4510 | 0.0102 |   12893 B |
