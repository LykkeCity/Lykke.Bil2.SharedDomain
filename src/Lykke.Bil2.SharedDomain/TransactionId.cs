using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(TransactionIdTypeConverter))]
    public sealed class TransactionId : BaseStringValueType<TransactionId>
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
