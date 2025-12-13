```c#
public class FieldKeyword
{
  [CompilerGenerated]
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  private string <MessageWithFieldKeyword>k__BackingField;

  public string MessageWithFieldKeyword
  {
    get => this.<MessageWithFieldKeyword>k__BackingField;
    set
    {
      this.<MessageWithFieldKeyword>k__BackingField = value ?? throw new ArgumentNullException(nameof(value));
    }
  }
}
```
