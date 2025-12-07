using System.Runtime.CompilerServices;
using WhatsNewCSharp14.Features;
using WhatsNewCSharp14.Tests;

long.DoSomethingLong();
42L.DoSomethingInstance();

int doSomething = ExtensionMembers.DoSomething();

ExtensionProps.get_Test(new object());
ExtensionProps.set_Test(new object(), 42);

IEnumerable<byte> bytes = byte.FromOne(42);
IEnumerable<int> ints = int.FromOne(42);

FieldKeyword.Do();

FirstClassSpans.Do();

UserDefinedCompoundAssignment.Do();

// Unbound generic types allowed in the nameof
Console.WriteLine(nameof(List<>)); // Prints "List"

// The null-conditional member access operators ?. and ?[],
// can now be used on the left-hand side of an assignment or compound assignment.
List<int>? list = null;
list?.Capacity = 10;
list?.Capacity += 10;
list?[0] = 1;

list = new();
list?.Capacity = 10;
list?.Capacity += 10;
list?.Add(7);
list?[0] = 42;
Console.WriteLine(list.Capacity);
Console.WriteLine(list[0]);