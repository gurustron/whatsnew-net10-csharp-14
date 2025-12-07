# What's new in .NET 10 and C#14

### What's new in C# 14


1. The null-conditional member access operators, `?.` and `?[]`, 
   can now be used on the left hand side of an assignment or compound assignment.
2. Lambda parameters improvements 
3. New partial members - ctors and events
4. Extension members
5. Field Keyword
6. User Defined Compound Assignment

### Performance improvements

1. Stackalloc
2. Devirtualization
3. Bounds checking
   1. Cloning
      ```csharp
       private int[] _arr = new int[16];

       [Benchmark]
       public void Test()
       {
           int[] arr = _arr;
           arr[0] = 2;
           arr[1] = 3;
           arr[2] = 5;
           arr[3] = 8;
           arr[4] = 13;
           arr[5] = 21;
           arr[6] = 34;
           arr[7] = 55;
       }
       ``` 
   
       ```csharp
       if (arr.Length >= 8)
       {
           arr[0] = 2;
           arr[1] = 3;
           arr[2] = 5;
           arr[3] = 8;
           arr[4] = 13;
           arr[5] = 21;
           arr[6] = 34;
           arr[7] = 55;
       }
       else
       {
           // the same
       }
      ```
4. 