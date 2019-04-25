using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Enum describing reason of the transaction estimation failure.
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy), new object[0], false)]
    public enum TransactionEstimationError
    {
        /// <summary>
        /// there is not enough balance on the some of the source addresses. Transaction can be estimated later,
        /// once funds are refilled, with exactly the same parameters or amount to transfer should be reduced.
        /// </summary>
        [EnumMember(Value = "notEnoughBalance")]
        NotEnoughBalance,
    }
}