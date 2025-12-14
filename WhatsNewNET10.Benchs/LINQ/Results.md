#### ContainsWithComparerBenchs

| Method   | Runtime   |      Mean | Ratio |
|----------|-----------|----------:|------:|
| Contains | .NET 9.0  | 265.95 us |  1.00 |
| Contains | .NET 10.0 |  97.73 us |  0.37 |                                                                                                                 

.NET 10:

```csharp
source.TryGetSpan<TSource>(out span) 
    ? span.Contains<TSource>(value, comparer) // MemoryExtensions.Contains<T>(this ReadOnlySpan<T> span, T value, IEqualityComparer<T>? comparer = null) =>
    : Enumerable.ContainsIterate<TSource>(source, value, comparer);
```

#### ContainsBenchs

| Method                 | Runtime   |         Mean | Ratio | Allocated | Alloc Ratio |
|------------------------|-----------|-------------:|------:|----------:|------------:|
| AppendContains         | .NET 9.0  |  2,164.79 ns |  1.00 |      88 B |        1.00 |
| AppendContains         | .NET 10.0 |     84.72 ns |  0.04 |      56 B |        0.64 |                                                                      
|                        |           |              |       |           |             |
| ConcatContains         | .NET 9.0  |  2,240.27 ns |  1.00 |      88 B |        1.00 |
| ConcatContains         | .NET 10.0 |     90.68 ns |  0.04 |      56 B |        0.64 |
|                        |           |              |       |           |             |
| DefaultIfEmptyContains | .NET 9.0  |     87.45 ns |  1.00 |         - |          NA |
| DefaultIfEmptyContains | .NET 10.0 |     82.82 ns |  0.95 |         - |          NA |
|                        |           |              |       |           |             |
| DistinctContains       | .NET 9.0  | 18,979.52 ns | 1.002 |   58656 B |       1.000 |
| DistinctContains       | .NET 10.0 |     83.29 ns | 0.004 |      64 B |       0.001 |
|                        |           |              |       |           |             |
| OrderByContains        | .NET 9.0  | 12,424.07 ns | 1.000 |   12280 B |       1.000 |
| OrderByContains        | .NET 10.0 |    101.63 ns | 0.008 |      88 B |       0.007 |
|                        |           |              |       |           |             |
| ReverseContains        | .NET 9.0  |    718.28 ns |  1.00 |    4072 B |        1.00 |
| ReverseContains        | .NET 10.0 |     79.84 ns |  0.11 |      48 B |        0.01 |
|                        |           |              |       |           |             |
| UnionContains          | .NET 9.0  | 19,456.10 ns | 1.001 |   58664 B |       1.000 |
| UnionContains          | .NET 10.0 |     85.13 ns | 0.004 |      72 B |       0.001 |
|                        |           |              |       |           |             |
| SelectManyContains     | .NET 9.0  |  2,239.66 ns |  1.00 |     192 B |        1.00 |
| SelectManyContains     | .NET 10.0 |    105.84 ns |  0.05 |     128 B |        0.67 |
|                        |           |              |       |           |             |
| WhereSelectContains    | .NET 9.0  |  1,492.85 ns |  1.00 |     104 B |        1.00 |
| WhereSelectContains    | .NET 10.0 |    304.55 ns |  0.20 |     104 B |        1.00 |


#### LINQ2ObjectsBenchs

| Method          |     Mean | Ratio | Allocated | Alloc Ratio |
|-----------------|---------:|------:|----------:|------------:|
| LeftJoin_Manual | 42.81 us |  1.00 |  65.84 KB |        1.00 |                                                                                                     
| LeftJoin_Linq   | 21.30 us |  0.50 |  36.95 KB |        0.56 |