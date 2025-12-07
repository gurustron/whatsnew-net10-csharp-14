using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD", "ids")]
public class StartEndCheckBench
{
    public IEnumerable<int[]> Ids { get; } = [[1, 2, 3, 4, 5, 1]];

    [Benchmark]
    [ArgumentsSource(nameof(Ids))]
    public bool StartAndEndAreSame(int[] ids) => ids[0] == ids[^1];
}