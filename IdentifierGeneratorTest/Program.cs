using BenchmarkDotNet.Running;
using IdentifierGeneratorTest;

//Identifier generator = new Identifier();
// Guid guid = Guid.NewGuid();
// Console.WriteLine($"Base64: {generator.NewId_FromGuidBase64(guid)}"); 
// Console.WriteLine($"Base64 substring: {generator.NewId_FromGuidBase64Substring(guid)}"); 
// Console.WriteLine($"ShortId: {generator.NewId_FromShortId()}"); 
// Console.WriteLine(generator.NewId_FromHashId()); 

BenchmarkRunner.Run<Benchmarks>();