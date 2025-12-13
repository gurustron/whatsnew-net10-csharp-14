```c#
[Extension]
public static class ExtensionMembers
{
  public static int DoSomething()
  {
    return 42;
  }

  [Extension]
  public static long DoSomething(this long name)
  {
    return name;
  }

  public static long DoSomethingLong()
  {
    return 42;
  }
  
  // Metadata members
  [Extension]
  [SpecialName]
  public sealed class <G>$BA41CFE2B5EDAEB8C1B9062F59ED4D69
  {
    [ExtensionMarker("<M>$BA41CFE2B5EDAEB8C1B9062F59ED4D69")]
    public static int DoSomething()
    {
      throw null;
    }

    [SpecialName]
    public static class <M>$BA41CFE2B5EDAEB8C1B9062F59ED4D69
    {
      [CompilerGenerated]
      [SpecialName]
      public static void <Extension>$([In] int obj0)
      {
      }
    }

    [SpecialName]
    public static class <M>$B3FEBCDB8BB81580ACA2A6723EF75B1C
    {
      [CompilerGenerated]
      [SpecialName]
      private static void <Extension>$(int name)
      {
      }
    }
  }

  [Extension]
  [SpecialName]
  public sealed class <G>$E8CA98ACBCAEE63BB261A3FD4AF31675
  {
    [ExtensionMarker("<M>$0CEEE8F2559F317FC8DF13D55C0019D1")]
    public long DoSomething()
    {
      throw null;
    }

    [ExtensionMarker("<M>$0CEEE8F2559F317FC8DF13D55C0019D1")]
    public static long DoSomethingLong()
    {
      throw null;
    }

    [SpecialName]
    public static class <M>$E8CA98ACBCAEE63BB261A3FD4AF31675
    {
      [CompilerGenerated]
      [SpecialName]
      private static void <Extension>$([In] long obj0)
      {
      }
    }

    [SpecialName]
    public static class <M>$0CEEE8F2559F317FC8DF13D55C0019D1
    {
      [CompilerGenerated]
      [SpecialName]
      public static void <Extension>$(long name)
      {
      }
    }
  }
}
```

So you can just call methods on `ExtensionMembers` class - `int i = ExtensionMembers.DoSomething()`

```csharp
public static class ExtensionProps
{
  public static bool get_Value(object val) => val is IEnumerable<int>;

  public static int get_Test(object val) => 42;

  public static void set_Test(object val, int value) => Console.WriteLine(value);

  [SpecialName]
  public sealed class <G>$C43E2675C7BBF9284AF22FB8A9BF0280
  {
    [ExtensionMarker("<M>$9109205604813664E88C4F17BCF3C8ED")]
    public bool Value
    {
      [ExtensionMarker("<M>$9109205604813664E88C4F17BCF3C8ED")] get => throw null;
    }

    [ExtensionMarker("<M>$9109205604813664E88C4F17BCF3C8ED")]
    public int Test
    {
      [ExtensionMarker("<M>$9109205604813664E88C4F17BCF3C8ED")] get => throw null;
      [ExtensionMarker("<M>$9109205604813664E88C4F17BCF3C8ED")] set => throw null;
    }

    [SpecialName]
    public static class <M>$9109205604813664E88C4F17BCF3C8ED
    {
      [CompilerGenerated]
      [SpecialName]
      public static void <Extension>$(object val)
      {
      }
    }
  }
}
```