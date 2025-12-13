namespace WhatsNewNET10.DemoRunner.Demos;

public class ShuffleDemos
{
#if NET10_0_OR_GREATER
    public static void Do()
    {
        List<int> list = Enumerable.Sequence(start: 1, endInclusive: 7, step: 1).ToList();
        IEnumerable<int> result = list.Shuffle();
        Console.WriteLine(string.Join(",", result));
        Environment.Exit(0);
    }
#endif
}