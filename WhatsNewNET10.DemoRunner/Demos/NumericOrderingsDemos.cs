using System.Globalization;

namespace WhatsNewNET10.DemoRunner.Demos;

public class NumericOrderingsDemos
{
    public static void Do()
    {
        string[] things = ["paul", "bob", "lauren", "107", "90"];

        var numericStringComparer =
            StringComparer.Create(CultureInfo.InvariantCulture, CompareOptions.NumericOrdering);

        foreach (var item in things.Order(numericStringComparer))
        {
            Console.WriteLine(item);
        }

        Environment.Exit(0);
    }
}