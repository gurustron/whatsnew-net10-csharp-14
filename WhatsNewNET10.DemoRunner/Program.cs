using System.Diagnostics;
using System.Runtime.CompilerServices;

// dotnet run -c Release -f net9.0
// dotnet run -c Release -f net10.0
// export DOTNET_JitDisasmSummary=1
const int Iterations = 100_000;
const int Cycles = 30;

Console.WriteLine($"Running {Environment.Version}, {Iterations} per cycle, {Cycles} cycles...");

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
    Console.WriteLine($"{c:00}: {elapsed / Iterations:N0} ns, {diffMem / Iterations:N0} bytes");
} 
[MethodImpl(MethodImplOptions.NoInlining)]
static void Test() // g__Test|0_0
{
    Process(new string[] { "a", "b", "c" });

    // Should be inlined which will allow the array to be stack allocated
    static void Process(string[] inputs) 
    {
        foreach (string input in inputs)
        {
            Use(input);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Use(string input)
        {
        }
    }
}

[MethodImpl(MethodImplOptions.NoInlining)]
static void TestStackObjectAllocations()
{
    Process(new string[] { "a", "b", "c" });

    // Should be inlined which will allow the array to be stack allocated
    static void Process(string[] inputs) 
    {
        foreach (string input in inputs)
        {
            Use(input);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Use(string input)
        {
        }
    }
}