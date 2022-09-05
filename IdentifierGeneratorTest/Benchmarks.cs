using BenchmarkDotNet.Attributes;

namespace IdentifierGeneratorTest
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    // Set iterationCount (optional)
    // [IterationCount(100)] 
    [RankColumn]
    public class Benchmarks
    {
        private readonly Identifier  identifier;
        private readonly Guid guid;
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
