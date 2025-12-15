using System.Diagnostics;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.StackAllocs;

[MemoryDiagnoser(displayGenColumns: false)]
// [DisassemblyDiagnoser]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class StopwatchStackAllocBench
{
    [Benchmark]
    public TimeSpan WithNew()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Nop();
        sw.Stop();

        return sw.Elapsed;
    }

    [Benchmark]
    public TimeSpan WithStartNew()
    {
        Stopwatch sw = Stopwatch.StartNew();
        Nop();
        sw.Stop();

        return sw.Elapsed;
    }

    [Benchmark]
    public Stopwatch WithNewReturn()
    {
        Stopwatch sw = new Stopwatch();
        Nop();
        sw.Stop();

        return sw;
    }

    [Benchmark]
    public TimeSpan WithNewPass()
    {
        Stopwatch sw = new Stopwatch();
        Nop(sw);
        sw.Stop();

        return sw.Elapsed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Nop(Stopwatch _) {}
    }

    [Benchmark]
    public TimeSpan WithNewPassInlined()
    {
        Stopwatch sw = new Stopwatch();
        NopInlined(sw);
        sw.Stop();

        return sw.Elapsed;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void NopInlined(Stopwatch _) {}
    }

    [Benchmark]
    public TimeSpan WithNewPassByRef()
    {
        Stopwatch sw = new Stopwatch();
        NopByRef(in sw);
        sw.Stop();

        return sw.Elapsed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void NopByRef(in Stopwatch _) {}
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Nop(){}

}
