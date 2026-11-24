```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,955.71 ns | 536.852 ns | 355.094 ns | 0.8333 |   31149 B |
| Xml_ListObjectsStructures | 78,202.69 ns | 440.028 ns | 291.051 ns | 1.2563 |   37492 B |
| Xml_DateTimes             | 23,265.21 ns | 180.187 ns | 119.182 ns | 0.5556 |   18028 B |
| Xml_WriteRequestBody      | 19,519.88 ns |  17.979 ns |   9.403 ns | 0.4682 |   13880 B |
| Xml_HeaderOnlyResponse    |     92.35 ns |   0.099 ns |   0.059 ns | 0.0108 |     304 B |
| Xml_SmallResponse         |  2,362.59 ns |   9.662 ns |   5.750 ns | 0.4568 |   12968 B |
