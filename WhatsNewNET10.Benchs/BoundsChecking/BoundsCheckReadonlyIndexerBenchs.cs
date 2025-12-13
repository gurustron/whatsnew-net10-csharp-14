using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class BoundsCheckReadonlyIndexerBenchs
{
    private static readonly int[] s_array = new int[3];

    [Benchmark]
    public int Read() => s_array[2];
}