using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using WhatsNewNET10.DemoRunner.Demos;

// dotnet run -c Release -f net9.0
// dotnet run -c Release -f net10.0
// export DOTNET_JitDisasmSummary=1
const int Iterations = 100_000;
const int Cycles = 30;
Console.WriteLine("----------------");
Console.WriteLine($"Running {Environment.Version}, {Iterations} per cycle, {Cycles} cycles...");
Console.WriteLine("----------------");
// Prepared Data
int[] values = Enumerable.Range(1, 100_000).ToArray();
var regex = new Regex(@"[a-z]+");
var input = "abc12323qwhgehg/sdad/sads+_)*&^%$#@!";
var sw = Stopwatch.StartNew();
// End of Prepared Data

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

// g__Test|0_0
[MethodImpl(MethodImplOptions.NoInlining)]
static void Test()
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
        static void Use(string _) { }
    }
}

static void TestIEnumerableDevirtualization(IEnumerable<int> values)
{
    int sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }

    Use(sum);

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Use(int _) { }
}

static void TestLinqContains(IEnumerable<int> values)
{
    var result = values.Order().Contains(-1);
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Use(int val) {}
}

static void TestRegexMatchesCount(Regex regex, string input)
{
#if NET9_0
    var result = regex.Matches(input).Count;
#elif NET10_0_OR_GREATER
    var result = regex.Count(input);
#endif

    Use(result); 

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Use(int _) {}
}