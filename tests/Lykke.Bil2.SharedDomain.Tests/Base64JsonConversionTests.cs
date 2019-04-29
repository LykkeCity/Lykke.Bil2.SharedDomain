using Newtonsoft.Json;
using NUnit.Framework;

namespace Lykke.Bil2.SharedDomain.Tests
{
    [TestFixture]
    public class Base64JsonConversionTests
    {
        private class TypeWithBase64Property
        {
            public Base64String Base64Property { get; set; }
        }

        [Test]
        [TestCase(null, ExpectedResult = "{\"Base64Property\":null}")]
        [TestCase("", ExpectedResult = "{\"Base64Property\":\"\"}")]
        [TestCase("the string", ExpectedResult = "{\"Base64Property\":\"dGhlIHN0cmluZw==\"}")]
        public string Can_be_serialized(string stringValue)
        {
            var obj = new TypeWithBase64Property
            {
                Base64Property = Base64String.Encode(stringValue)
            };

            return JsonConvert.SerializeObject(obj);
        }

        [Test]
        [TestCase("{\"Base64Property\":null}", ExpectedResult = null)]
        [TestCase("{\"Base64Property\":\"\"}", ExpectedResult = null)]
        [TestCase("{\"Base64Property\":\"dGhlIHN0cmluZw==\"}", ExpectedResult = "the string")]
        public string Can_be_deserialized(string json)
        {
            var obj = JsonConvert.DeserializeObject<TypeWithBase64Property>(json);

            return obj.Base64Property?.DecodeToString();
        }
    }
}
