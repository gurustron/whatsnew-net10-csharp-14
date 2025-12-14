#### StopwatchStackAllocBench


| Method  | Runtime   |     Mean | Ratio | Allocated | Alloc Ratio |
|---------|-----------|---------:|------:|----------:|------------:|
| WithNew | .NET 9.0  | 58.42 ns |  1.00 |      40 B |        1.00 |
| WithNew | .NET 10.0 | 44.13 ns |  0.76 |         - |        0.00 |                                                                                 


| Method                  | Runtime   |     Mean | Allocated |
|-------------------------|-----------|---------:|----------:|
| WithStartNew            | .NET 10.0 | 46.90 ns |         - |
| WithStartNewReturn      | .NET 10.0 | 61.66 ns |      40 B |
| WithStartNewPass        | .NET 10.0 | 65.20 ns |      40 B |
| WithStartNewPassInlined | .NET 10.0 | 49.54 ns |         - |
| WithStartNewPassByRef   | .NET 10.0 | 64.89 ns |      40 B |


Full:

| Method                  | Runtime   |     Mean | Ratio | Allocated | Alloc Ratio |
|-------------------------|-----------|---------:|------:|----------:|------------:|
| WithNew                 | .NET 9.0  | 68.34 ns |  1.01 |      40 B |        1.00 |
| WithNew                 | .NET 10.0 | 42.45 ns |  0.63 |         - |        0.00 |                                                                                 
|                         |           |          |       |           |             |
| WithStartNew            | .NET 9.0  | 77.92 ns |  1.01 |      40 B |        1.00 |
| WithStartNew            | .NET 10.0 | 46.90 ns |  0.61 |         - |        0.00 |
|                         |           |          |       |           |             |
| WithStartNewReturn      | .NET 9.0  | 61.47 ns |  1.01 |      40 B |        1.00 |
| WithStartNewReturn      | .NET 10.0 | 61.66 ns |  1.01 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPass        | .NET 9.0  | 69.99 ns |  1.01 |      40 B |        1.00 |
| WithStartNewPass        | .NET 10.0 | 65.20 ns |  0.94 |      40 B |        1.00 |
|                         |           |          |       |           |             |
| WithStartNewPassInlined | .NET 9.0  | 59.03 ns |  1.00 |      40 B |        1.00 |
| WithStartNewPassInlined | .NET 10.0 | 49.54 ns |  0.84 |         - |        0.00 |
|                         |           |          |       |           |             |
| WithStartNewPassByRef   | .NET 9.0  | 59.29 ns |  1.00 |      40 B |        1.00 |
| WithStartNewPassByRef   | .NET 10.0 | 64.89 ns |  1.09 |      40 B |        1.00 |

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