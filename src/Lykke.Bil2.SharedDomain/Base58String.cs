using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.Exceptions;
using Lykke.Bil2.SharedDomain.TypeConverters;
using Multiformats.Base;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Some binary object or probably json object encoded as base58 string.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ImmutableObject(true)]
    [TypeConverter(typeof(Base58StringTypeConverter))]
    public sealed class Base58String :
        IComparable<Base58String>,
        IEquatable<Base58String>,
        IFormattable
    {
        private static Regex _formatRegex;

        /// <summary>
        /// Base58 encoded value
        /// </summary>
        public string Value { get; }

        static Base58String()
        {
            _formatRegex = new Regex("^[1-9A-HJ-NP-Za-km-z]*$", RegexOptions.Compiled);
        }

        public Base58String(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!_formatRegex.IsMatch(value))
                throw new Base58StringConversionException("String is not valid Base58 string", value);

            Value = value;
        }

        public static Base58String Encode(string stringValue)
        {
            if (stringValue == null)
            {
                return null;
            }

            var bytes = Encoding.UTF8.GetBytes(stringValue);
            
            return Encode(bytes);
        }

        public static Base58String Encode(byte[] bytesValue)
        {
            if (bytesValue == null)
            {
                return null;
            }

            var value = Multibase.Base58.Encode(bytesValue);

            return new Base58String(value);
        }

        public string DecodeToString()
        {
            var bytes = DecodeToBytes();

            return Encoding.UTF8.GetString(bytes);
        }

        public byte[] DecodeToBytes()
        {
            return Multibase.Base58.Decode(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value;
        }

        public int CompareTo(Base58String other)
        {
            if (ReferenceEquals(this, other)) 
                return 0;
            if (ReferenceEquals(null, other)) 
                return 1;
            return string.Compare(Value, other.Value, StringComparison.Ordinal);
        }

        public bool Equals(Base58String other)
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
            return obj is Base58String base58 && Equals(base58);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public static bool operator ==(Base58String a, Base58String b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Base58String a, Base58String b)
        {
            return !Equals(a, b);
        }
    }
}
