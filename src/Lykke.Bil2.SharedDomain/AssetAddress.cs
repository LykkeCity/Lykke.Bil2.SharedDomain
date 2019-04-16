using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(AssetAddressTypeConverter))]
    public sealed class AssetAddress : BaseStringValueType<AssetAddress>
    {
        public AssetAddress(string value) :
            base(value)
        {
        }

        public static implicit operator AssetAddress(string value)
        {
            return value != null ? new AssetAddress(value) : null;
        }
   
        public static implicit operator string(AssetAddress value)
        {
            return value?.Value;
        }
    }
}
