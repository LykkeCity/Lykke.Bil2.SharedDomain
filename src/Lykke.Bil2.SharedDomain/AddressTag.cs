using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(AddressTagTypeConverter))]
    public sealed class AddressTag : BaseStringValueType<AddressTag>
    {
        public AddressTag(string value) :
            base(value)
        {
        }

        public static implicit operator AddressTag(string value)
        {
            return value != null ? new AddressTag(value) : null;
        }
   
        public static implicit operator string(AddressTag value)
        {
            return value?.Value;
        }
    }
}
