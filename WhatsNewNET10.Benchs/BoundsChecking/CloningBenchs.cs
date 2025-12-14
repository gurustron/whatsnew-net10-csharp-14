using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class CloningBenchs
{
    private int[] _arr = new int[16];

    [Benchmark]
    public void Test()
    {
        int[] arr = _arr;
        arr[0] = 2;
        arr[1] = 3;
        arr[2] = 5;
        arr[3] = 8;
        arr[4] = 13;
        arr[5] = 21;
        arr[6] = 34;
        arr[7] = 55;
    }
}