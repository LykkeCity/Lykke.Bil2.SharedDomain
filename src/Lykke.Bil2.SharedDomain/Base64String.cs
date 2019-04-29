using System;
using System.Buffers;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Lykke.Bil2.SharedDomain.Exceptions;
using Lykke.Bil2.SharedDomain.TypeConverters;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Some binary object or probably json object encoded as base64 string.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ImmutableObject(true)]
    [TypeConverter(typeof(Base64StringTypeConverter))]
    public sealed class Base64String :
        IComparable<Base64String>,
        IEquatable<Base64String>,
        IFormattable
    {
        private static Regex _formatRegex;

        /// <summary>
        /// Base64 encoded value
        /// </summary>
        public string Value { get; }

        static Base64String()
        {
            _formatRegex = new Regex("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$", RegexOptions.Compiled);
        }

        public Base64String(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!_formatRegex.IsMatch(value))
                throw new Base64StringConversionException("String is not valid Base64 string", value);

            Value = value;
        }

        public static Base64String Encode(string stringValue)
        {
            if (stringValue == null)
            {
                return null;
            }

            var bytes = Encoding.UTF8.GetBytes(stringValue);
            
            return Encode(bytes);
        }

        public static Base64String Encode(byte[] bytesValue)
        {
            if (bytesValue == null)
            {
                return null;
            }

            var value = Convert.ToBase64String(bytesValue);

            return new Base64String(value);
        }

        public string DecodeToString()
        {
            var bytes = DecodeToBytes();

            return Encoding.UTF8.GetString(bytes);
        }

        public byte[] DecodeToBytes()
        {
            return Convert.FromBase64String(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value;
        }

        public int CompareTo(Base64String other)
        {
            if (ReferenceEquals(this, other)) 
                return 0;
            if (ReferenceEquals(null, other)) 
                return 1;
            return string.Compare(Value, other.Value, StringComparison.Ordinal);
        }

        public bool Equals(Base64String other)
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
            return obj is Base64String base64 && Equals(base64);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public static bool operator ==(Base64String a, Base64String b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Base64String a, Base64String b)
        {
            return !Equals(a, b);
        }
    }
}
