using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(AssetIdTypeConverter))]
    public sealed class AssetId : BaseStringValueType<AssetId>
    {
        public AssetId(string value) :
            base(value)
        {
        }

        public static implicit operator AssetId(string value)
        {
            return value != null ? new AssetId(value) : null;
        }
   
        public static implicit operator string(AssetId value)
        {
            return value?.Value;
        }
    }
}
