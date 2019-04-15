using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Name of the integration dependency.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(DependencyNameTypeConverter))]
    public class DependencyName : BaseStringValueType<DependencyName>
    {
        /// <summary>
        /// Name of the integration dependency.
        /// </summary>
        public DependencyName(string value) : 
            base(value)
        {
        }

        public static implicit operator DependencyName(string value)
        {
            return value != null ? new DependencyName(value) : null;
        }
   
        public static implicit operator string(DependencyName value)
        {
            return value?.Value;
        }
    }
}