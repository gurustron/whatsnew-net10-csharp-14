using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace NET10.Benchs.Devirtualization;

[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
[DisassemblyDiagnoser]
public class GenericGDVBenchs
{
    [Benchmark]
    public bool GenericEqualsStrings() => GenericEquals("abc", "abc");

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool GenericEquals<T>(T a, T b) => EqualityComparer<T>.Default.Equals(a, b);
}