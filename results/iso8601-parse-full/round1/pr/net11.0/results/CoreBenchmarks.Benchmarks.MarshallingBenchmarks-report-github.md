```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method               | Mean      | Error     | StdDev    | Gen0   | Allocated |
|--------------------- |----------:|----------:|----------:|-------:|----------:|
| Xml_DateTimes        | 11.533 μs | 0.1802 μs | 0.1192 μs | 0.5939 |  17.62 KB |
| Json_DateTimeStrings |  3.568 μs | 0.0212 μs | 0.0140 μs | 0.2007 |    5.9 KB |
