using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqPerformanceBenchmark;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
internal class Benchmark
{
    private IEnumerable<int> items;

    [Params(100)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup() => items = Enumerable.Range(1, Size).ToArray();

    [Benchmark]
    public int Min() => items.Min();

    [Benchmark]
    public int Max() => items.Max();

    [Benchmark]
    public int Sum() => items.Sum();

    [Benchmark]
    public double Average() => items.Average();
}