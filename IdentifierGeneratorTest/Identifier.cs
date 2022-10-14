
using HashidsNet;
using shortid;
using shortid.Configuration;
using System.Security.Cryptography;

namespace IdentifierGeneratorTest
{
    public class Identifier
    {
        Hashids hashIds;
        Random rng;
        public Identifier()
        {
            hashIds = new Hashids("this is my salt");
            rng = new Random();
       

        }

        // 1WIXVZtbA0qKPcZ
        public string NewId_FromGuidBase64Substring(Guid guid, int length) {
            return Convert.ToBase64String(guid.ToByteArray())
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Substring(0, length)
                    .ToUpper();

        }
        // 1WIXVZtbA0qKPcZ
        public string NewId_FromGuidShorted(Guid guid, int length)
        {
            return guid.ToString("N").Substring(0, length).ToUpper();

        }

        // KXTRVzGVUoOY
        // Can be customized through options in params
        public string NewId_FromShortId(int length)
        {
            var options = new GenerationOptions(useSpecialCharacters: false, useNumbers: true, length: length);
            return ShortId.Generate(options).ToUpper();
        }

        public string NewId_FromHashId(int value)
        {
            return hashIds.Encode(value).ToUpper();
        }

        public int NewId_FromRandomInt()
        {
            return rng.Next(int.MaxValue); 
        }

        public string NewId_FromSHA256SubString(int length)
        {
            var guid = Guid.NewGuid();
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(guid.ToByteArray());
            return BitConverter.ToString(hash).Replace("-", "")[..length];
        }
    }
}
