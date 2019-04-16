using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(SemverTypeConverter))]
    public sealed class Semver : BaseStringValueType<Semver>
    {
        public Semver(string value) :
            base(value)
        {
        }

        public static implicit operator Semver(string value)
        {
            return value != null ? new Semver(value) : null;
        }
   
        public static implicit operator string(Semver value)
        {
            return value?.Value;
        }
    }
}
