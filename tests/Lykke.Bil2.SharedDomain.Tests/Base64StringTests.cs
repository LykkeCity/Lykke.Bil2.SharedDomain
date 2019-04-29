using System;
using Lykke.Bil2.SharedDomain.Exceptions;
using NUnit.Framework;

namespace Lykke.Bil2.SharedDomain.Tests
{
    [TestFixture]
    public class Base64StringTests
    {
        [Test]
        [TestCase("V3JpdHRlbiBlbnF1aXJlIHBhaW5mdWwgeWUgdG8gb2ZmaWNlcyBmb3JtaW5nIGl0LiBUaGVuIHNvIGRvZXMgb3ZlciBzZW50IGR1bGwgb24u")]
        [TestCase("dGhlIHN0cmluZw==")]
        public void Can_create_from_valid_string(string base64Value)
        {
            var value = new Base64String(base64Value);

            Assert.AreEqual(base64Value, value.Value);
        }
        
        [Test]
        public void Cant_create_from_null_string()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new Base64String(null));
        }

        [Test]
        [TestCase("not a base64 string")]
        public void Cant_create_from_invalid_string(string base64Value)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<Base64StringConversionException>(() => new Base64String(base64Value));
        }

        [Test]
        [TestCase("", ExpectedResult = "")]
        [TestCase("the string", ExpectedResult = "dGhlIHN0cmluZw==")]
        public string Can_encode_string(string stringValue)
        {
            var value = Base64String.Encode(stringValue);

            return value.Value;
        }

        [Test]
        [TestCase(new byte[0], ExpectedResult = "")]
        [TestCase(new byte[]{ 0x00, 0x50, 0xAF, 0xFF, 0x45 }, ExpectedResult = "AFCv/0U=")]
        public string Can_encode_bytes(byte[] bytesValue)
        {
            var value = Base64String.Encode(bytesValue);

            return value.Value;
        }

        [Test]
        [TestCase("", ExpectedResult = "")]
        [TestCase("dGhlIHN0cmluZw==", ExpectedResult = "the string")]
        public string Can_decode_to_string(string base64Value)
        {
            var value = new Base64String(base64Value);

            return value.DecodeToString();
        }

        [Test]
        [TestCase("", ExpectedResult = new byte[0])]
        [TestCase("AFCv/0U=", ExpectedResult = new byte[]{ 0x00, 0x50, 0xAF, 0xFF, 0x45 })]
        public byte[] Can_decode_to_bytes(string base64Value)
        {
            var value = new Base64String(base64Value);

            return value.DecodeToBytes().ToArray();
        }

        [Test]
        [TestCase("dGhlIHN0cmluZw==", "dGhlIHN0cmluZw==", ExpectedResult = true)]
        [TestCase("", "", ExpectedResult = true)]
        [TestCase("dGhlIHN0cmluZw==", "", ExpectedResult = false)]
        [TestCase("", "dGhlIHN0cmluZw==", ExpectedResult = false)]
        [TestCase("dGhlIHN0cmluZw==", "V3JpdHRlbiBlbnF1aXJlIHBhaW5mdWwgeWUgdG8gb2ZmaWNlcyBmb3JtaW5nIGl0LiBUaGVuIHNvIGRvZXMgb3ZlciBzZW50IGR1bGwgb24u", ExpectedResult = false)]
        public bool Test_equation(string a, string b)
        {
            var a64 = new Base64String(a);
            var b64 = new Base64String(b);

            return Equals(a64, b64);
        }

        [Test]
        [TestCase("dGhlIHN0cmluZw==", "dGhlIHN0cmluZw==", ExpectedResult = 0)]
        [TestCase("", "", ExpectedResult = 0)]
        [TestCase("dGhlIHN0cmluZw==", "", ExpectedResult = 100)]
        [TestCase("", "dGhlIHN0cmluZw==", ExpectedResult = -100)]
        [TestCase("dGhlIHN0cmluZw==", "V3JpdHRlbiBlbnF1aXJlIHBhaW5mdWwgeWUgdG8gb2ZmaWNlcyBmb3JtaW5nIGl0LiBUaGVuIHNvIGRvZXMgb3ZlciBzZW50IGR1bGwgb24u", ExpectedResult = 14)]
        public int Test_comparison(string a, string b)
        {
            var a64 = new Base64String(a);
            var b64 = new Base64String(b);

            return a64.CompareTo(b64);
        }

        [Test]
        [TestCase("dGhlIHN0cmluZw==", "dGhlIHN0cmluZw==", ExpectedResult = true)]
        [TestCase("", "", ExpectedResult = true)]
        [TestCase("dGhlIHN0cmluZw==", "", ExpectedResult = false)]
        [TestCase("", "dGhlIHN0cmluZw==", ExpectedResult = false)]
        [TestCase("dGhlIHN0cmluZw==", "V3JpdHRlbiBlbnF1aXJlIHBhaW5mdWwgeWUgdG8gb2ZmaWNlcyBmb3JtaW5nIGl0LiBUaGVuIHNvIGRvZXMgb3ZlciBzZW50IGR1bGwgb24u", ExpectedResult = false)]
        public bool Test_hash_code_equation(string a, string b)
        {
            var a64 = new Base64String(a);
            var b64 = new Base64String(b);

            return a64.GetHashCode() == b64.GetHashCode();
        }

    }
}
