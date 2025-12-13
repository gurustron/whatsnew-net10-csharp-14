using System.Collections;
using System.Numerics;

namespace WhatsNewCSharp14.Features;

public static class ExtensionMembers
{
    // only static, e.g. invoked on type - int.DoSomething()
    extension(int /*receiver parameter*/)
    {
        public static int DoSomething() => 42;

        // will not compile:
        // public int DoSomething() => 42;
    }

    extension(long)
    {
        // Type 'ExtensionMembers' already defines a member called
        // 'DoSomething' with the same parameter types
        // public static long DoSomething() => 42; // will not compile
    }

    // static and instance
    extension(long name /*named receiver parameter*/)
    {
        public long DoSomething() => name; // 42L.DoSomething()
        public static long DoSomethingLong() => 42;
    }

    extension(int name /*named receiver parameter*/)
    {
        // Type 'MyExtensionMembers' already defines a member called 'DoSomething'
        // with the same parameter types
        // public int DoSomething() => name;
    }
}

public static class ExtensionProps
{
    extension(object val)
    {
        public bool Value => val is IEnumerable<int>;

        public int Test
        {
            get
            {
                return 42;
                // return field; // error CS9282: This member is not allowed in an extension block
            }
            set
            {
                Console.WriteLine(value);
                // field = value; // error CS9282: This member is not allowed in an extension block
            }
        }
    }
}
public static class E
{
    extension<T>(T[] ts) // can apply generic constraints for T
    {
        // It is an error for members to declare type parameters or parameters
        // (as well as local variables and local functions directly within the member body)
        // with the same name as a type parameter or receiver parameter of the extension declaration.
        // public void M3(int T, string ts) { }          // Error: Cannot reuse names `T` and `ts`
        // public void M4<T, ts>(string s) { }           // Error: Cannot reuse names `T` and `ts`

        // Though can be used as names
        public void T() { M(ts); } // Generated static method M<T>(T[]) is found
        public void ts() { }

        public void M()
        {
            // ts(); // Error: Method, delegate, or event is expected
            // T(ts); // Error: T is a type parameter
        }
    }

    extension<T>(T) where T : INumber<T>
    {
        public static IEnumerable<T> FromOne(int count)
        {
            var start = T.One;
            for (int i = 0; i < count; i++)
            {
                yield return start++;
            }
        }
    }
}