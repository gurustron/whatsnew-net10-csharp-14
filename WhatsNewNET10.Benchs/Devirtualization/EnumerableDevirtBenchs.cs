using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.Devirtualization;

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
[DisassemblyDiagnoser]
public class EnumerableDevirtualizationBenchs
{

    private int[] _values = Enumerable.Range(1, 100).ToArray();

    [Benchmark]
    public int Sum() => Sum(_values);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int Sum(IEnumerable<int> values)
    {
        int sum = 0;
        foreach (int value in values)
        {
            sum += value;
        }

        return sum;
    }
}
