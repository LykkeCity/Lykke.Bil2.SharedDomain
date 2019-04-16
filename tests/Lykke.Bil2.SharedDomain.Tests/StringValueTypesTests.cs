using NUnit.Framework;

namespace Lykke.Bil2.SharedDomain.Tests
{
    [TestFixture]
    public class StringValueTypesTests
    {
        private class TestStringValueType : BaseStringValueType<TestStringValueType>
        {
            public TestStringValueType(string value) :
                base(value)
            {
            }
        }

        [Test]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(null, ExpectedResult = null)]
        public string TestAssetIdConversion(string value) => (AssetId) value;

        [Test]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(null, ExpectedResult = null)]
        public string TestAddressConversion(string value) => (Address) value;

        [Test]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(null, ExpectedResult = null)]
        public string TestAddressTagConversion(string value) => (AddressTag) value;

        [Test]
        [TestCase("123", "1234", ExpectedResult = -52)]
        [TestCase("1234", "123", ExpectedResult = 52)]
        [TestCase("123", "123", ExpectedResult = 0)]
        public int TestComparison(string a, string b) => 
            new TestStringValueType(a).CompareTo(new TestStringValueType(b));
       
        [Test]
        [TestCase("123", "1234", ExpectedResult = false)]
        [TestCase("1234", "123", ExpectedResult = false)]
        [TestCase("123", "123", ExpectedResult = true)]
        public bool TestEquation(string a, string b) => 
            new TestStringValueType(a).Equals(new TestStringValueType(b));

        [Test]
        [TestCase("123", "1234", ExpectedResult = false)]
        [TestCase("1234", "123", ExpectedResult = false)]
        [TestCase("123", "123", ExpectedResult = true)]
        public bool TestEquationToObject(string a, string b) => 
            new TestStringValueType(a).Equals((object)new TestStringValueType(b));

        [Test]
        [TestCase("123", "1234", ExpectedResult = false)]
        [TestCase("1234", "123", ExpectedResult = false)]
        [TestCase("123", "123", ExpectedResult = true)]
        public bool TestHashCode(string a, string b) => 
            new TestStringValueType(a).GetHashCode() == new TestStringValueType(b).GetHashCode();
    }
}
