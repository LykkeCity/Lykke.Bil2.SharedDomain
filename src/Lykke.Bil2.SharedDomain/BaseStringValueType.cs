using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain
{
    [PublicAPI]
    [ImmutableObject(true)]
    public abstract class BaseStringValueType<TConcrete> :
        IComparable<TConcrete>,
        IEquatable<TConcrete>,
        IFormattable

        where TConcrete : BaseStringValueType<TConcrete>
    {
        /// <summary>
        /// The value
        /// </summary>
        public string Value { get; }

        protected BaseStringValueType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Should be not empty string", nameof(value));

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value;
        }

        public int CompareTo(TConcrete other)
        {
            if (ReferenceEquals(this, other)) 
                return 0;
            if (ReferenceEquals(null, other)) 
                return 1;
            return string.Compare(Value, other.Value, StringComparison.Ordinal);
        }

        public bool Equals(TConcrete other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            return obj is TConcrete concreteObject && Equals(concreteObject);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public static bool operator ==(BaseStringValueType<TConcrete> a, BaseStringValueType<TConcrete> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(BaseStringValueType<TConcrete> a, BaseStringValueType<TConcrete> b)
        {
            return !Equals(a, b);
        }
    }
}
