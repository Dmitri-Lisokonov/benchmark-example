using IdentifierGeneratorTest;
using Shouldly;
using Xunit.Abstractions;

namespace Tests
{
    public class IdentifierTests
    {
        private readonly Identifier identifier;
        private readonly ITestOutputHelper output;
        private readonly int identifierLength = 8;
        public IdentifierTests(ITestOutputHelper outputHelper)
        {
            identifier = new Identifier();
            output = outputHelper;
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 1
        [InlineData(1000000)] // Uniquenesss: 1
        [InlineData(10000000)] // Uniquenesss: 0,9999977
        public void NewId_FromGuidBase64Substring(int length)
        {
            var identifiers = new List<string>();
            for(int i = 0; i < length; i++)
            {
                Guid guid = Guid.NewGuid();
                var result = identifier.NewId_FromGuidBase64Substring(guid, identifierLength);
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 0,99998
        [InlineData(1000000)] // Uniquenesss: 0,999865
        [InlineData(10000000)] // Uniquenesss: 0,9988328
        public void NewId_FromGuidShorted(int length)
        {
            var identifiers = new List<string>();
            for (int i = 0; i < length; i++)
            {
                Guid guid = Guid.NewGuid();
                var result = identifier.NewId_FromGuidShorted(guid, identifierLength);
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 1
        [InlineData(1000000)] // Uniquenesss: 1
        [InlineData(10000000)] // Uniquenesss: 0,9999958
        public void NewId_FromShortId(int length)
        {
            var identifiers = new List<string>();
            for (int i = 0; i < length; i++)
            {
                Guid guid = Guid.NewGuid();
                var result = identifier.NewId_FromShortId(identifierLength);
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 0,99996
        [InlineData(1000000)] // Uniquenesss: 0,999528
        [InlineData(10000000)] // Uniquenesss: 0,9951262
        public void NewId_FromHashId(int length)
        {
            Random rnd = new Random();
            var identifiers = new List<string>();
            for (int i = 0; i < length; i++)
            {
                var result = identifier.NewId_FromHashId(rnd.Next(0, int.MaxValue));
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 0,99996
        [InlineData(1000000)] // Uniquenesss: 0,999761
        [InlineData(10000000)] // Uniquenesss: 0,9976872
        public void NewId_FromRandomInt(int length)
        {
            Random rnd = new Random();
            var identifiers = new List<int>();
            for (int i = 0; i < length; i++)
            {
                var result = identifier.NewId_FromRandomInt();
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

        [Theory]
        [InlineData(10000)] // Uniquenesss: 1
        [InlineData(100000)] // Uniquenesss: 0,99999
        [InlineData(1000000)] // Uniquenesss: 0,999879
        [InlineData(10000000)] // Uniquenesss: 0,9988063
        public void NewId_FromSHA256SubString(int length)
        {
            var identifiers = new List<string>();
            for (int i = 0; i < length; i++)
            {
                var result = identifier.NewId_FromSHA256SubString(identifierLength);
                identifiers.Add(result);
            }
            var uniqueCount = identifiers.Distinct().Count();
            var totalCount = identifiers.Count;
            double unique = (double)uniqueCount / (double)totalCount;
            output.WriteLine($"Unique for {length} with length 6: {unique}");
            totalCount.ShouldBe(length);
            unique.ShouldBeGreaterThan(0.7);
        }

    }
}