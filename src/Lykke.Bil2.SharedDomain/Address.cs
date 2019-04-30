using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(AddressTypeConverter))]
    public sealed class Address : BaseStringValueType<Address>
    {
        /// <summary>
        /// Address can't be recognized.
        /// </summary>
        public static readonly Address Unrecognized = new Address("_Unrecognized_");

        public Address(string value) :
            base(value)
        {
        }

        public static implicit operator Address(string value)
        {
            return value != null ? new Address(value) : null;
        }
   
        public static implicit operator string(Address value)
        {
            return value?.Value;
        }
    }
}
