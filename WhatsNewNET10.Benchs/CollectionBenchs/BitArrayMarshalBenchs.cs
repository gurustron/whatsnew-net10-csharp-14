using System.Collections;
using System.Numerics.Tensors;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace WhatsNewNET10.Benchs.CollectionBenchs;

[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class BitArrayMarshalBenchs
{
    private BitArray _bits1, _bits2;

    [GlobalSetup]
    public void Setup()
    {
        Random r = new(42);
        byte[] bytes = new byte[128];

        r.NextBytes(bytes);
        _bits1 = new BitArray(bytes);

        r.NextBytes(bytes);
        _bits2 = new BitArray(bytes);
    }

    [Benchmark(Baseline = true)]
    public long HammingDistanceManual()
    {
        long distance = 0;
        for (int i = 0; i < _bits1.Length; i++)
        {
            if (_bits1[i] != _bits2[i])
            {
                distance++;
            }
        }

        return distance;
    }
    
#if NET10_0_OR_GREATER
    
    [Benchmark]
    public long HammingDistanceTensorPrimitives() =>
        TensorPrimitives.HammingBitDistance( // from System.Numerics.Tensors nuget
            CollectionsMarshal.AsBytes(_bits1),
            CollectionsMarshal.AsBytes(_bits2));
#else
[Benchmark]
    public long HammingDistanceTensorPrimitives() => 1;
#endif
}