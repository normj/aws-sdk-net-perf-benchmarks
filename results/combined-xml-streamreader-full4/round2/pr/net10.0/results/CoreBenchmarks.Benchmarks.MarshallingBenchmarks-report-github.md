```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,514.43 ns | 228.246 ns | 135.826 ns | 0.8446 |   31108 B |
| Xml_ListObjectsStructures | 80,026.29 ns | 511.295 ns | 338.190 ns | 1.2755 |   37527 B |
| Xml_DateTimes             | 23,220.54 ns | 120.855 ns |  79.938 ns | 0.5547 |   17987 B |
| Xml_WriteRequestBody      | 20,843.92 ns |  24.269 ns |  12.693 ns | 0.4178 |   13880 B |
| Xml_HeaderOnlyResponse    |     94.12 ns |   0.714 ns |   0.425 ns | 0.0105 |     304 B |
| Xml_SmallResponse         |  2,392.50 ns |  14.961 ns |   9.896 ns | 0.4591 |   12968 B |
