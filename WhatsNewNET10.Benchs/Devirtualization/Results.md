#### ReadOnlyCollectionEnumeratorDevirtualizationBench

> devirtualization for array’s interface implementation

Which is faster?

```csharp
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public partial class Tests
{
    private ReadOnlyCollection<int> _list = new(Enumerable.Range(1, 1000).ToArray());

    [Benchmark]
    public int SumEnumerable()
    {
        int sum = 0;
        foreach (var item in _list)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public int SumForLoop()
    {
        ReadOnlyCollection<int> list = _list;
        int sum = 0;
        int count = list.Count;
        for (int i = 0; i < count; i++)
        {
            sum += _list[i];
        }
        return sum;
    }
}
```

| Method                | Runtime   |       Mean | Ratio | Allocated | Alloc Ratio |
|-----------------------|-----------|-----------:|------:|----------:|------------:|
| SumEnumerableViaArray | .NET 9.0  |   879.3 ns |  1.00 |      32 B |        1.00 |
| SumEnumerableViaArray | .NET 10.0 |   725.5 ns |  0.83 |      32 B |        1.00 |
|                       |           |            |       |           |             |
| SumForLoopViaArray    | .NET 9.0  | 2,495.0 ns |  1.00 |         - |          NA |
| SumForLoopViaArray    | .NET 10.0 |   671.3 ns |  0.27 |         - |          NA |
|                       |           |            |       |           |             |
| SumEnumerableViaList  | .NET 9.0  | 1,255.7 ns |  1.00 |      40 B |        1.00 |
| SumEnumerableViaList  | .NET 10.0 | 1,065.7 ns |  0.85 |      40 B |        1.00 |
|                       |           |            |       |           |             |
| SumForLoopViaList     | .NET 9.0  |   968.9 ns |  1.00 |         - |          NA |
| SumForLoopViaList     | .NET 10.0 |   924.4 ns |  0.95 |         - |          NA |

`ReadOnlyCollection<T>` wraps an arbitrary `IList<T>` and uses it's `GetEnumerator` and indexer.
In .NET 9, it struggles to devirtualize calls to the interface implementations specifically on `T[]`,
so it won’t devirtualize either the `_list.GetEnumerator()` call nor the `_list[index]` call. 
However, the enumerator that’s returned is just a normal type that implements `IEnumerator<T>`, 
and the JIT has no problem devirtualizing its `MoveNext` and `Current` members. 
Which means that we’re actually paying a lot more going through the indexer, because for N elements,
we’re having to make N interface calls, whereas with the enumerator,
we only need the one with GetEnumerator interface call and then no more after that.

#### GenericGDVBenchs

| Method               | Runtime   |     Mean | Ratio | Code Size |
|----------------------|-----------|---------:|------:|----------:|
| GenericEqualsStrings | .NET 10.0 | 1.605 ns |  0.76 |     215 B |                                                                                   
| GenericEqualsStrings | .NET 9.0  | 2.122 ns |  1.00 |     203 B |

## .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3 (Job: .NET 10(Runtime=.NET 10.0))

```assembly
; NET10.Benchs.Devirtualization.GenericGDVBenchs.Test()
       mov       rdi,7B789CA217E0
       mov       rdx,7B37ECE09F78
       mov       rsi,rdx
       jmp       qword ptr [7B789C9D6490]; NET10.Benchs.Devirtualization.GenericGDVBenchs.GenericEquals[[System.__Canon, System.Private.CoreLib]](System.__Canon, System.__Canon)
; Total bytes of code 29
```
```assembly
; NET10.Benchs.Devirtualization.GenericGDVBenchs.GenericEquals[[System.__Canon, System.Private.CoreLib]](System.__Canon, System.__Canon)
       push      rbp
       push      r15
       push      rbx
       sub       rsp,10
       lea       rbp,[rsp+20]
       mov       [rbp-18],rdi
       mov       rbx,rsi
       mov       r15,rdx
       mov       rsi,[rdi+18]
       mov       rsi,[rsi+10]
       test      rsi,rsi
       je        short M01_L02
M01_L00:
       mov       rdi,rsi
       call      System.Runtime.CompilerServices.StaticsHelpers.GetGCStaticBase(System.Runtime.CompilerServices.MethodTable*)
       mov       rdi,[rax]
       mov       rsi,offset MT_System.Collections.Generic.StringEqualityComparer
       cmp       [rdi],rsi
       jne       short M01_L07
       cmp       rbx,r15
       jne       short M01_L03
       mov       eax,1
M01_L01:
       add       rsp,10
       pop       rbx
       pop       r15
       pop       rbp
       ret
M01_L02:
       mov       rsi,7B789CA05280
       call      qword ptr [7B789BE5F750]; System.Runtime.CompilerServices.GenericsHelpers.Method(IntPtr, IntPtr)
       mov       rsi,rax
       jmp       short M01_L00
M01_L03:
       test      rbx,rbx
       je        short M01_L06
       test      r15,r15
       je        short M01_L06
       mov       edi,[rbx+8]
       cmp       edi,[r15+8]
       jne       short M01_L06
       add       rbx,0C
       lea       rsi,[r15+0C]
       add       edi,edi
       mov       edx,edi
       cmp       rdx,8
       je        short M01_L04
       mov       rdi,rbx
       call      qword ptr [7B789BE57A50]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M01_L05
M01_L04:
       mov       rax,[rbx]
       cmp       rax,[rsi]
       sete      al
       movzx     eax,al
M01_L05:
       jmp       short M01_L01
M01_L06:
       xor       eax,eax
       jmp       short M01_L01
M01_L07:
       mov       rsi,rbx
       mov       rdx,r15
       mov       rax,[rdi]
       mov       rax,[rax+40]
       call      qword ptr [rax+20]
       jmp       short M01_L01
; Total bytes of code 186
```

## .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3 (Job: .NET 9(Runtime=.NET 9.0))

```assembly
; NET10.Benchs.Devirtualization.GenericGDVBenchs.Test()
       mov       rdi,7AFF3B920320
       mov       rdx,7AFF28C0A4C8
       mov       rsi,rdx
       jmp       qword ptr [7AFF3B8F5500]; NET10.Benchs.Devirtualization.GenericGDVBenchs.GenericEquals[[System.__Canon, System.Private.CoreLib]](System.__Canon, System.__Canon)
; Total bytes of code 29
```
```assembly
; NET10.Benchs.Devirtualization.GenericGDVBenchs.GenericEquals[[System.__Canon, System.Private.CoreLib]](System.__Canon, System.__Canon)
       push      rbp
       push      r15
       push      r14
       push      rbx
       push      rax
       lea       rbp,[rsp+20]
       mov       [rbp-20],rdi
       mov       rbx,rsi
       mov       r15,rdx
       mov       rsi,[rdi+18]
       mov       rsi,[rsi+10]
       test      rsi,rsi
       je        short M01_L02
M01_L00:
       mov       rdi,rsi
       call      qword ptr [7AFF3AD65AD0]; System.Collections.Generic.EqualityComparer`1[[System.__Canon, System.Private.CoreLib]].get_Default()
       mov       rdi,rax
       mov       rax,offset MT_System.Collections.Generic.StringEqualityComparer
       cmp       [rdi],rax
       jne       short M01_L05
       cmp       rbx,r15
       jne       short M01_L03
       mov       r14d,1
M01_L01:
       movzx     eax,r14b
       add       rsp,8
       pop       rbx
       pop       r14
       pop       r15
       pop       rbp
       ret
M01_L02:
       mov       rsi,7AFF3B911D60
       call      CORINFO_HELP_RUNTIMEHANDLE_METHOD
       mov       rsi,rax
       jmp       short M01_L00
M01_L03:
       test      rbx,rbx
       je        short M01_L04
       test      r15,r15
       je        short M01_L04
       mov       edx,[rbx+8]
       cmp       edx,[r15+8]
       jne       short M01_L04
       lea       rdi,[rbx+0C]
       add       edx,edx
       lea       rsi,[r15+0C]
       call      qword ptr [7AFF3AD67810]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       mov       r14d,eax
       jmp       short M01_L01
M01_L04:
       xor       r14d,r14d
       jmp       short M01_L01
M01_L05:
       mov       rsi,rbx
       mov       rdx,r15
       mov       rax,[rdi]
       mov       rax,[rax+40]
       call      qword ptr [rax+20]
       mov       r14d,eax
       jmp       short M01_L01
; Total bytes of code 174
```

#### EnumerableDevirtualizationBenchs

```assembly
; NET10.Benchs.Devirtualization.EnumerableDevirtualizationBenchs.Sum(System.Collections.Generic.IEnumerable`1<Int32>)
       push      rbp
       push      rbx
       push      rax
       lea       rbp,[rsp+10]
       xor       ebx,ebx
       mov       rax,offset MT_System.Int32[]
       cmp       [rdi],rax
       jne       short M01_L03
       mov       eax,[rdi+8]
       xor       ecx,ecx
       test      eax,eax
       je        short M01_L01
M01_L00:
       cmp       ecx,eax
       jae       short M01_L02
       mov       edx,ecx
       add       ebx,[rdi+rdx*4+10]
       inc       ecx
       cmp       ecx,eax
       jb        short M01_L00
M01_L01:
       mov       eax,ebx
       add       rsp,8
       pop       rbx
       pop       rbp
       ret
M01_L02:
       mov       edi,ecx
       call      qword ptr [73A07F5ACD80]
       int       3
M01_L03:
       mov       r11,73A07DA504D8
       call      qword ptr [r11]
       mov       rdi,rax
       mov       [rbp-10],rdi
M01_L04:
       mov       rdi,[rbp-10]
       mov       r11,[rdi]
       mov       r11,73A07DA504E0
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L05
       mov       rdi,[rbp-10]
       mov       r11,73A07DA504E8
       call      qword ptr [r11]
       add       eax,ebx
       mov       ebx,eax
       jmp       short M01_L04
M01_L05:
       mov       rdi,[rbp-10]
       mov       r11,73A07DA504F0
       call      qword ptr [r11]
       jmp       short M01_L01
       push      rax
       cmp       qword ptr [rbp-10],0
       je        short M01_L06
       mov       rdi,[rbp-10]
       mov       r11,73A07DA504F0
       call      qword ptr [r11]
M01_L06:
       nop
       add       rsp,8
       ret
; Total bytes of code 185
```


```assembly
; NET10.Benchs.Devirtualization.EnumerableDevirtualizationBenchs.Sum(System.Collections.Generic.IEnumerable`1<Int32>)
       push      rbp
       push      r15
       push      r14
       push      rbx
       sub       rsp,18
       lea       rbp,[rsp+30]
       mov       [rbp-30],rsp
       xor       ebx,ebx
       mov       r11,704F42E504D8
       call      qword ptr [r11]
       mov       rdi,rax
       mov       [rbp-20],rdi
M01_L00:
       mov       r15,[rdi]
       mov       r14,offset MT_System.SZGenericArrayEnumerator<System.Int32>
       cmp       r15,r14
       jne       short M01_L04
       mov       eax,[rdi+8]
       inc       eax
       cmp       eax,[rdi+0C]
       jae       short M01_L02
       mov       [rdi+8],eax
       mov       ecx,[rdi+8]
       cmp       ecx,[rdi+0C]
       jae       short M01_L03
       mov       rax,[rdi+10]
       cmp       ecx,[rax+8]
       jae       short M01_L05
       mov       r15d,[rax+rcx*4+10]
M01_L01:
       add       ebx,r15d
       jmp       short M01_L00
M01_L02:
       mov       eax,[rdi+0C]
       mov       [rdi+8],eax
       jmp       short M01_L06
M01_L03:
       mov       edi,ecx
       call      qword ptr [704F44907C18]
       int       3
M01_L04:
       mov       r11,704F42E504E0
       call      qword ptr [r11]
       test      eax,eax
       je        short M01_L07
       mov       rdi,[rbp-20]
       mov       r11,704F42E504E8
       call      qword ptr [r11]
       mov       r15d,eax
       mov       rdi,[rbp-20]
       jmp       short M01_L01
M01_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
M01_L06:
       mov       eax,ebx
       add       rsp,18
       pop       rbx
       pop       r14
       pop       r15
       pop       rbp
       ret
M01_L07:
       mov       rdi,[rbp-20]
       mov       r11,704F42E504F0
       call      qword ptr [r11]
       jmp       short M01_L06
       push      rbp
       push      r15
       push      r14
       push      rbx
       push      rax
       mov       rbp,[rdi]
       mov       [rsp],rbp
       lea       rbp,[rbp+30]
       cmp       qword ptr [rbp-20],0
       je        short M01_L08
       mov       rdi,[rbp-20]
       mov       r15,[rdi]
       mov       r14,offset MT_System.SZGenericArrayEnumerator<System.Int32>
       cmp       r15,r14
       je        short M01_L08
       mov       r11,704F42E504F0
       call      qword ptr [r11]
M01_L08:
       nop
       add       rsp,8
       pop       rbx
       pop       r14
       pop       r15
       pop       rbp
       ret
; Total bytes of code 269
```


| Method | Runtime   |     Mean | Ratio | Code Size | Allocated | Alloc Ratio |
|--------|-----------|---------:|------:|----------:|----------:|------------:|
| Sum    | .NET 9.0  | 98.36 ns |  1.00 |     279 B |      32 B |        1.00 |
| Sum    | .NET 10.0 | 43.95 ns |  0.45 |     195 B |         - |        0.00 | 

With dynamic PGO, the instrumented code for Sum will see that values is generally an int[], 
and it’ll be able to emit a specialized code path in the optimized Sum implementation for when it is. 
And then with this ability to do conditional escape analysis,
for the common path the JIT can see that the resulting GetEnumerator produces an IEnumerator<int> 
that never escapes, such that along with all of the relevant methods being devirtualized and inlined, 
the enumerator can be stack allocated.

#### GDVBenchs

.NET 10.0.0

| Method          |     Mean |
|-----------------|---------:|
| ViaInterface    | 18.02 us |                                                                                                          
| ViaAbstractBase | 13.29 us |
| Concrete        | 13.33 us |

.NET 9.0.10

| Method          |     Mean | 
|-----------------|---------:|
| ViaInterface    | 18.60 us |                                                                                                          
| ViaAbstractBase | 13.28 us | 
| Concrete        | 13.34 us |