using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    
    public sealed class BlockId : BaseImplicitToStringValueType<BlockId>
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