#### BitArrayMarshalBenchs

| Method                          | Runtime   | Mean          | Ratio | 
|-------------------------------- |---------- |--------------:|------:|
| HammingDistanceManual           | .NET 10.0 | 1,365.7313 ns | 0.993 |                                                                 
| HammingDistanceTensorPrimitives | .NET 10.0 |    70.4893 ns | 0.051 | 
| HammingDistanceManual           | .NET 9.0  | 1,375.8202 ns | 1.000 | 
