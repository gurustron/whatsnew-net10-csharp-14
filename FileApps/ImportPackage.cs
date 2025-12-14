#:package Colorful.Console@1.2.15
using Console = Colorful.Console;

Console.WriteAscii("Hello, world!!!");


for (int i = 0; i < args.Length; i++)
{
    Console.WriteAscii($"Arg[{i}] = [{args[i]}]");
}
