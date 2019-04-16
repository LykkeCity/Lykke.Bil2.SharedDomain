using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    
    public sealed class TransactionId : BaseImplicitToStringValueType<TransactionId>
    {
        public TransactionId(string value) :
            base(value)
        {
        }

        public static implicit operator TransactionId(string value)
        {
            return value != null ? new TransactionId(value) : null;
        }
   
        public static implicit operator string(TransactionId value)
        {
            return value?.Value;
        }
    }
}