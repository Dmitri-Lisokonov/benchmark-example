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
        private readonly int length = 8;
        private readonly Identifier  identifier;
        private readonly Guid guid;
        public Benchmarks()
        {
            identifier = new Identifier();
            guid = Guid.NewGuid();
        }

        [Benchmark]
        public void NewId_FromGuidBase64Substring()
        {
            identifier.NewId_FromGuidBase64Substring(guid, length);
        }

        [Benchmark]
        public void NewId_FromGuidShorted()
        {
            identifier.NewId_FromGuidShorted(guid, length);
        }

        [Benchmark]
        public void NewId_FromShortId()
        {
            identifier.NewId_FromShortId(length);
        }

        [Benchmark]
        public void NewId_FromHashId()
        {
            identifier.NewId_FromHashId(length);
        }

        [Benchmark]
        public void NewId_FromRandomInt()
        {
            identifier.NewId_FromShortId(length);
        }

        [Benchmark]
        public void NewId_FromSHA256SubString()
        {
            identifier.NewId_FromSHA256SubString(length);
        }
    }
}
