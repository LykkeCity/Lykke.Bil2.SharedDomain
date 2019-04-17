using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Id of the coin.
    /// </summary>
    [PublicAPI, DataContract]
    public class CoinId : IEquatable<CoinId>
    {
        /// <summary>
        /// Id of the transaction within which coin was created.
        /// </summary>
        [JsonProperty("transactionId"), DataMember(Order = 0)]
        public TransactionId TransactionId { get; }

        /// <summary>
        /// Number of the coin inside the transaction within which coin was created.
        /// </summary>
        [JsonProperty("coinNumber"), DataMember(Order = 1)]
        public int CoinNumber { get; }

        public CoinId(string transactionId, int coinNumber)
            : this(new TransactionId(transactionId), coinNumber)
        {
            if (string.IsNullOrWhiteSpace(transactionId))
                throw new ArgumentException("Should be not empty string", nameof(transactionId));
        }

        public CoinId(TransactionId transactionId, int coinNumber)
        {
            if (transactionId == null)
                throw new ArgumentNullException(nameof(transactionId));
            
            if (coinNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(coinNumber), coinNumber, "Should be zero or positive number");
            
            TransactionId = transactionId;
            CoinNumber = coinNumber;
        }

        public override string ToString()
        {
            return $"{TransactionId}:{CoinNumber}";
        }

        public bool Equals(CoinId other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(TransactionId, other.TransactionId) && CoinNumber == other.CoinNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((CoinId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((TransactionId != null ? TransactionId.GetHashCode() : 0) * 397) ^ CoinNumber;
            }
        }

        public static bool operator ==(CoinId a, CoinId b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(CoinId a, CoinId b)
        {
            return !Equals(a, b);
        }
    }
}
