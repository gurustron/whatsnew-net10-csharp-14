#### StopwatchStackAllocBench


| Method  | Runtime   |     Mean | Ratio | Allocated | Alloc Ratio |
|---------|-----------|---------:|------:|----------:|------------:|
| WithNew | .NET 9.0  | 58.42 ns |  1.00 |      40 B |        1.00 |
| WithNew | .NET 10.0 | 44.13 ns |  0.76 |         - |        0.00 |                                                                                 


| Method                  | Runtime   |     Mean | Allocated |
|-------------------------|-----------|---------:|----------:|
| WithStartNew            | .NET 10.0 | 36.27 ns |         - |
| WithNewReturn           | .NET 10.0 | 12.38 ns |      40 B |
| WithStartNewPass        | .NET 10.0 | 47.60 ns |      40 B |
| WithStartNewPassInlined | .NET 10.0 | 36.96 ns |         - |
| WithStartNewPassByRef   | .NET 10.0 | 47.31 ns |      40 B |



Full:

| Method                  | Runtime   |     Mean | Ratio | Allocated | Alloc Ratio |
|-------------------------|-----------|---------:|------:|----------:|------------:|
| WithNew                 | .NET 10.0 | 36.43 ns |  0.72 |         - |        0.00 |                                                                                 
| WithNew                 | .NET 9.0  | 50.66 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNew            | .NET 10.0 | 36.27 ns |  0.70 |         - |        0.00 |
| WithStartNew            | .NET 9.0  | 52.04 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewReturn      | .NET 10.0 | 12.38 ns |  0.87 |      40 B |        1.00 |
| WithStartNewReturn      | .NET 9.0  | 14.19 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPass        | .NET 10.0 | 47.60 ns |  0.92 |      40 B |        1.00 |
| WithStartNewPass        | .NET 9.0  | 52.10 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPassInlined | .NET 10.0 | 36.96 ns |  0.75 |         - |        0.00 |
| WithStartNewPassInlined | .NET 9.0  | 49.42 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPassByRef   | .NET 10.0 | 47.31 ns |  0.93 |      40 B |        1.00 |
| WithStartNewPassByRef   | .NET 9.0  | 51.00 ns |  1.00 |      40 B |        1.00 |

| Method                  | Runtime   |     Mean | Ratio | Allocated | Alloc Ratio |
|-------------------------|-----------|---------:|------:|----------:|------------:|
| WithNew                 | .NET 9.0  | 58.42 ns |  1.00 |      40 B |        1.00 |
| WithNew                 | .NET 10.0 | 44.13 ns |  0.76 |         - |        0.00 |                                                                                 
|                         |           |          |       |           |             |
| WithStartNew            | .NET 9.0  | 59.05 ns |  1.00 |      40 B |        1.00 |
| WithStartNew            | .NET 10.0 | 45.66 ns |  0.77 |         - |        0.00 |
|                         |           |          |       |           |             |
| WithStartNewReturn      | .NET 9.0  | 50.60 ns |  1.00 |      40 B |        1.00 |
| WithStartNewReturn      | .NET 10.0 | 54.78 ns |  1.08 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPass        | .NET 9.0  | 58.52 ns |  1.00 |      40 B |        1.00 |
| WithStartNewPass        | .NET 10.0 | 58.47 ns |  1.00 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPassInlined | .NET 9.0  | 55.32 ns |  1.00 |      40 B |        1.00 |
| WithStartNewPassInlined | .NET 10.0 | 44.04 ns |  0.80 |         - |        0.00 |
|                         |           |          |       |           |             |
| WithStartNewPassByRef   | .NET 9.0  | 55.58 ns |  1.00 |      40 B |        1.00 |
| WithStartNewPassByRef   | .NET 10.0 | 56.73 ns |  1.02 |      40 B |        1.00 |

#### ArrayStackAllocBench

| Method          | Runtime   |      Mean | Ratio | Allocated | Alloc Ratio |
|-----------------|-----------|----------:|------:|----------:|------------:|
| ArrayStackAlloc | .NET 9.0  | 17.856 ns |  1.00 |      48 B |        1.00 |
| ArrayStackAlloc | .NET 10.0 |  4.886 ns |  0.27 |         - |        0.00 |                                                                                        