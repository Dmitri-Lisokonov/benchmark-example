
using shortid;
using System.Text.RegularExpressions;

namespace IdentifierGeneratorTest
{
    public class Identifier
    {

        // c9a646d3-9c61-4cb7-bfcd-ee2522c8f633
        public string NewId_FromGuid() => Guid.NewGuid().ToString();

        public string NewId_FromGuidBase64(Guid guid)
        {
            string base64Guid = Convert.ToBase64String(guid.ToByteArray());
            string result = Regex.Replace(base64Guid, "[/+=]", "");
            return result;
        }

        // 1WIXVZtbA0qKPcZ
        public string NewId_FromGuidBase64Substring(Guid guid) {
            return Convert.ToBase64String(guid.ToByteArray())
                    .Replace("/", "_")
                    .Replace("+", "-")
                    .Substring(0, 15);

        }
        // 1WIXVZtbA0qKPcZ
        public string NewId_FromGuidShorted(Guid guid)
        {
            return guid.ToString("N").Substring(0, 15);
        }

        // KXTR_VzGVUoOY
        // Can be customized through options in params
        public string NewId_FromShortId()
        {
            return ShortId.Generate();
        }

    }
}
