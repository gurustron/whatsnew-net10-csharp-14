using System.Diagnostics;
using System.Runtime.CompilerServices;

const int Iterations = 100_000;
const int Cycles = 15;

Console.WriteLine($"Running, {Iterations} per cycle, {Cycles} cycles...");

var sw = Stopwatch.StartNew();

for (int c = 0; c < Cycles; c++)
{
    long allocated = GC.GetAllocatedBytesForCurrentThread(); // GC.GetTotalAllocatedBytes(precise: true);
    sw.Restart();

    for (int i = 0; i < Iterations; i++)
    {
        Test();
    }
    sw.Stop();
    
    var diffMem = GC.GetAllocatedBytesForCurrentThread() - allocated;
    var elapsed = sw.Elapsed.TotalNanoseconds;
    Console.WriteLine($"{elapsed / Iterations:N0} ns, {diffMem / Iterations:N0} bytes");
}


[MethodImpl(MethodImplOptions.NoInlining)]
static void Test()
{
    
}