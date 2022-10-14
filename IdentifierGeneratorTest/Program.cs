using BenchmarkDotNet.Running;
using IdentifierGeneratorTest;

Identifier generator = new Identifier();
Guid guid = Guid.NewGuid();
int length = 8;
Console.WriteLine($"NewId_FromGuidBase64Substring: {generator.NewId_FromGuidBase64Substring(guid, length)}");
Console.WriteLine($"NewId_FromGuidShorted: {generator.NewId_FromGuidShorted(guid, length)}");
Console.WriteLine($"NewId_FromShortId: {generator.NewId_FromShortId(length)}");
Console.WriteLine($"NewId_FromHashId: {generator.NewId_FromHashId(int.MaxValue)}");
Console.WriteLine($"NewId_FromRandomInt: {generator.NewId_FromRandomInt()}");
Console.WriteLine($"NewId_FromSHA256SubString: {generator.NewId_FromSHA256SubString(length)}");



BenchmarkRunner.Run<Benchmarks>();