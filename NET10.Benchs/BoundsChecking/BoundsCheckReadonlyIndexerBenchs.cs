using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class BoundsCheckReadonlyIndexerBenchs
{
    private static int[] s_array = new int[3];

    [Benchmark]
    public int Read() => s_array[2];
}