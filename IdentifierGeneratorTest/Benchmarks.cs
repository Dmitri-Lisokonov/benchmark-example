using BenchmarkDotNet.Attributes;

namespace IdentifierGeneratorTest
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [IterationCount(100)] // Set iterationCount (optional)
    [RankColumn]
    public class Benchmarks
    {
        Identifier identifier;
        Guid guid;
        public Benchmarks()
        {
            identifier = new Identifier();
            guid = Guid.NewGuid();
        }

        [Benchmark]
        public void NewId_FromGuidBase64()
        {
            identifier.NewId_FromGuidBase64(guid);
        }

        [Benchmark]
        public void NewId_FromGuidBase64Substring()
        {
            identifier.NewId_FromGuidBase64Substring(guid);
        }

        [Benchmark]
        public void NewId_FromGuidShorted()
        {
            identifier.NewId_FromGuidBase64Substring(guid);
        }

        [Benchmark]
        public void NewId_FromShortId()
        {
            identifier.NewId_FromGuidBase64Substring(guid);
        }

    }
}
