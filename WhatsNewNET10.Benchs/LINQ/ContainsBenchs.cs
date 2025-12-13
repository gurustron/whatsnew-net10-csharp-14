using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.LINQ;

// TODO
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class ContainsBenchs
{
    private IEnumerable<int> _source = Enumerable.Range(0, 1000).ToArray();

    [Benchmark]
    public bool AppendContains() => _source.Append(100).Contains(999);

    [Benchmark]
    public bool ConcatContains() => _source.Concat(_source).Contains(999);

    [Benchmark]
    public bool DefaultIfEmptyContains() => _source.DefaultIfEmpty(42).Contains(999);

    [Benchmark]
    public bool DistinctContains() => _source.Distinct().Contains(999);

    [Benchmark]
    public bool OrderByContains() => _source.OrderBy(x => x).Contains(999);

    [Benchmark]
    public bool ReverseContains() => _source.Reverse().Contains(999);

    [Benchmark]
    public bool UnionContains() => _source.Union(_source).Contains(999);

    [Benchmark]
    public bool SelectManyContains() => _source.SelectMany(x => _source).Contains(999);

    [Benchmark]
    public bool WhereSelectContains() => _source.Where(x => true).Select(x => x).Contains(999);
}
