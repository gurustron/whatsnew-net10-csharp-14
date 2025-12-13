using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.LINQ;

[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class ContainsWithComparerBenchs
{
    private IEnumerable<int> _data = Enumerable.Range(0, 1_000_000).ToArray();

    [Benchmark]
    public bool Contains() => _data.Contains(int.MaxValue, EqualityComparer<int>.Default);
}