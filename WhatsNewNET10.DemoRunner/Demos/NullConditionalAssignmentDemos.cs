namespace WhatsNewNET10.DemoRunner.Demos;

public class NullConditionalAssignmentDemos
{
    public static void DoNull()
    {
        List<int>? list = null;
        list?.Capacity = 10;
        list?.Capacity += 10;
        list?[0] = 1;
        list?[0] = GetIntAndWriteToConsole();

        int GetIntAndWriteToConsole()
        {
            Console.WriteLine("Side effect"); // here we scare FP guys

            return 42;
        }

        Environment.Exit(0);
    }

    public static void DoNotNull()
    {
        List<int>? list = new();
        list?.Capacity = 10;
        list?.Capacity += 10;
        list?.Add(7);
        list?[0] = 42;
        Console.WriteLine(list!.Capacity);
        Console.WriteLine(list[0]);
        list?[0] = GetIntAndWriteToConsole();

        int GetIntAndWriteToConsole()
        {
            Console.WriteLine("Side effect"); // here we scare FP guys

            return 42;
        }

        Environment.Exit(0);
    }
}