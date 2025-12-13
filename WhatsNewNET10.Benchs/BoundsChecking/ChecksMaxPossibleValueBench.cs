using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.BoundsChecking;

[DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD", "value")]
public class ChecksMaxPossibleValueBench
{
    private static ReadOnlySpan<byte> data =>
    [
        01, 02, 03, 04, 05, 06, 07, 08,
        09, 10, 11, 12, 13, 14, 15, 16,
        17, 18, 19, 20, 21, 22, 23, 24,
        25, 26, 27, 28, 29, 30, 31, 32
    ];

    [Benchmark]
    [Arguments(uint.MaxValue)]
    public int TestBitMagic(uint value) => data[(int)(value >> 27)];
}