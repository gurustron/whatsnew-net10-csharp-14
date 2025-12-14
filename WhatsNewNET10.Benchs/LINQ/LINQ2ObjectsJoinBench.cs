using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.LINQ;

#if NET10_0_OR_GREATER
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class LINQ2ObjectsJoinBench
{
    private IEnumerable<int> Outer { get; } = Enumerable.Sequence(0, 1000, 2);
    private IEnumerable<int> Inner { get; } = Enumerable.Sequence(0, 1000, 3);

    [Benchmark(Baseline = true)]
    public int LeftJoin_Manual() =>
        ManualLeftJoin(Outer, Inner, o => o, i => i, (o, i) => o + i).Count();

    [Benchmark]
    public int LeftJoin_Linq() =>
        Outer.LeftJoin(Inner, o => o, i => i, (o, i) => o + i).Count();

    private static IEnumerable<TResult> ManualLeftJoin<TOuter, TInner, TKey, TResult>(
        IEnumerable<TOuter> outer, IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner?, TResult> resultSelector) =>
        outer
            .GroupJoin(inner, outerKeySelector, innerKeySelector, (o, inners) => (o, inners))
            .SelectMany(x => x.inners.DefaultIfEmpty(), (x, i) => resultSelector(x.o, i));
}
#endif