using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(BlockIdTypeConverter))]
    public sealed class BlockId : BaseStringValueType<BlockId>
    {
        public BlockId(string value) :
            base(value)
        {
        }

        public static implicit operator BlockId(string value)
        {
            return value != null ? new BlockId(value) : null;
        }
   
        public static implicit operator string(BlockId value)
        {
            return value?.Value;
        }
    }
}
