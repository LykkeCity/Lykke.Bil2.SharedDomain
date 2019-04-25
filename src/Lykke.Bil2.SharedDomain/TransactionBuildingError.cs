﻿using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Enum describing reason of the transaction building failure.
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy), new object[0], false)]
    public enum TransactionBuildingError
    {       
        /// <summary>
        /// there is not enough balance on the some of the source addresses. Transaction can be rebuilt later,
        /// funds are refilled, with exactly the same parameters or amount to transfer, including fee, should be reduced.
        /// </summary>
        [EnumMember(Value = "notEnoughBalance")]
        NotEnoughBalance,

        /// <summary>
        /// Fee amount is not enough to execute the transaction.
        /// Fee should be increased and transaction should be built again.
        /// </summary>
        [EnumMember(Value = "feeTooLow")]
        FeeTooLow,

        /// <summary>
        /// Integration can’t serve request right now due to workload or any other reason.
        /// Request should be retried later.
        /// </summary>
        [EnumMember(Value = "retryLater")]
        RetryLater 
    }
}
