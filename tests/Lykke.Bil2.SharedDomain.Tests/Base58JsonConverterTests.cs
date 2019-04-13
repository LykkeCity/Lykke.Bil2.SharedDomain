﻿using Newtonsoft.Json;
using NUnit.Framework;

namespace Lykke.Bil2.SharedDomain.Tests
{
    [TestFixture]
    public class Base58JsonConverterTests
    {
        private class TypeWithBase58Property
        {
            public Base58String Base58Property { get; set; }
        }

        [Test]
        [TestCase(null, ExpectedResult = "{\"Base58Property\":null}")]
        [TestCase("", ExpectedResult = "{\"Base58Property\":\"\"}")]
        [TestCase("the string", ExpectedResult = "{\"Base58Property\":\"7YKZiHCxdLJS6i\"}")]
        public string Can_be_serialized(string stringValue)
        {
            var obj = new TypeWithBase58Property
            {
                Base58Property = Base58String.Encode(stringValue)
            };

            return JsonConvert.SerializeObject(obj);
        }

        [Test]
        [TestCase("{\"Base58Property\":null}", ExpectedResult = null)]
        [TestCase("{\"Base58Property\":\"\"}", ExpectedResult = "")]
        [TestCase("{\"Base58Property\":\"7YKZiHCxdLJS6i\"}", ExpectedResult = "the string")]
        public string Can_be_deserialized(string json)
        {
            var obj = JsonConvert.DeserializeObject<TypeWithBase58Property>(json);

            return obj.Base58Property?.DecodeToString();
        }
    }
}
