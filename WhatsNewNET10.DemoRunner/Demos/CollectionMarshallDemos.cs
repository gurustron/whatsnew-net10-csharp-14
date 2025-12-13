using System.Runtime.InteropServices;

namespace WhatsNewNET10.DemoRunner.Demos;

public class CollectionMarshallDemos
{
#if NET10_0_OR_GREATER
    public static void Do()
    {
        List<int> list = Enumerable.Sequence(start: 1, endInclusive: 7, step: 1).ToList();
        var span = CollectionsMarshal.AsSpan(list);
        Random.Shared.Shuffle(span);
        Console.WriteLine(string.Join(",", list));
        Environment.Exit(0);
    }
#endif
}