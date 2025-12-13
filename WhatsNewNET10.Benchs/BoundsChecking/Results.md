#### BoundsCheckReadonlyIndexerBenchs

Needs to be `static readonly`. Without it 

## .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3 (Job: .NET 9(Runtime=.NET 9.0))

```assembly
; NET10.Benchs.BoundsChecking.BoundsCheckBenchs.Read()
       push      rax
       mov       rax,71AA8860A4C8
       mov       ecx,3
       cmp       ecx,2
       jbe       short M00_L00
       mov       eax,[rax+18]
       add       rsp,8
       ret
M00_L00:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 35
```

## .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3 (Job: .NET 10(Runtime=.NET 10.0))

```assembly
; NET10.Benchs.BoundsChecking.BoundsCheckBenchs.Read()
       mov       rax,72AB74609F78
       mov       eax,[rax+18]
       ret
; Total bytes of code 14
```

Without readonly:

## .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3 (Job: .NET 10(Runtime=.NET 10.0))

```assembly
; NET10.Benchs.BoundsChecking.BoundsCheckReadonlyIndexerBenchs.Read()
       push      rax
       mov       rax,7F8328000388
       mov       rax,[rax]
       cmp       dword ptr [rax+8],2
       jbe       short M00_L00
       mov       eax,[rax+18]
       add       rsp,8
       ret
M00_L00:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 34
```

| Method | Runtime   |      Mean | Code Size |
|--------|-----------|----------:|----------:|
| Read   | .NET 9.0  | 0.0020 ns |      35 B |
| Read   | .NET 10.0 | 0.0022 ns |      14 B |                                                                                  

#### ChecksMaxPossibleValueBench

## .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3 (Job: .NET 10(Runtime=.NET 10.0))

```assembly
; NET10.Benchs.BoundsChecking.ChecksMaxPossibleValueBench.TestBitMagic(UInt32)
       shr       esi,1B
       mov       eax,esi
       mov       rcx,7A1A5C040E50
       movzx     eax,byte ptr [rcx+rax]
       ret
; Total bytes of code 20
```

## .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3 (Job: .NET 9(Runtime=.NET 9.0))

```assembly
; NET10.Benchs.BoundsChecking.ChecksMaxPossibleValueBench.TestBitMagic(UInt32)
       push      rax
       shr       esi,1B
       cmp       esi,20
       jae       short M00_L00
       mov       eax,esi
       mov       rcx,78C24C632E50
       movzx     eax,byte ptr [rax+rcx]
       add       rsp,8
       ret
M00_L00:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 36
```

#### StartEndCheckBench

## .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3 (Job: .NET 10(Runtime=.NET 10.0))

```assembly
; NET10.Benchs.BoundsChecking.StartEndCheckBench.StartAndEndAreSame(Int32[])
       push      rax
       mov       eax,[rsi+8]
       test      eax,eax
       je        short M00_L00
       mov       ecx,[rsi+10]
       dec       eax
       cmp       ecx,[rsi+rax*4+10]
       sete      al
       movzx     eax,al
       add       rsp,8
       ret
M00_L00:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 34
```

## .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v3 (Job: .NET 9(Runtime=.NET 9.0))

```assembly
; NET10.Benchs.BoundsChecking.StartEndCheckBench.StartAndEndAreSame(Int32[])
       push      rax
       mov       eax,[rsi+8]
       test      eax,eax
       je        short M00_L00
       mov       ecx,[rsi+10]
       lea       edx,[rax-1]
       cmp       edx,eax
       jae       short M00_L00
       mov       eax,edx
       cmp       ecx,[rsi+rax*4+10]
       sete      al
       movzx     eax,al
       add       rsp,8
       ret
M00_L00:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 41
```