using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class BoundsCheckForReadonlyBenchs
{
    private readonly int[] s_array = new int[10];
    private int[] s_non_r_array = new int[10];

    [Benchmark]
    public int Sum()
    {
        var r = 0;
        for (int i = 0; i < s_array.Length; i++)
        {
            r += s_array[i];
        }
        return r;
    }
    
    [Benchmark]
    public int SumMutable()
    {
        var r = 0;
        for (int i = 0; i < s_non_r_array.Length; i++)
        {
            r += s_non_r_array[i];
        }
        return r;
    }
    
    [Benchmark]
    public int SumLocalCopy()
    {
        var localCopy = s_non_r_array;
        var r = 0;
        for (int i = 0; i < localCopy.Length; i++)
        {
            r += localCopy[i];
        }
        return r;
    }
}