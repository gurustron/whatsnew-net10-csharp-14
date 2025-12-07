using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using NET10.Benchs.Devirtualization;
using NET10.Benchs.StackAllocs;

var config = DefaultConfig.Instance
    .AddJob(Job.Default.WithId(".NET 9").WithRuntime(CoreRuntime.Core90).AsBaseline())
    .AddJob(Job.Default.WithId(".NET 10").WithRuntime(CoreRuntime.Core10_0))
    ;
BenchmarkRunner.Run<GenericGDVBenchs>(config);