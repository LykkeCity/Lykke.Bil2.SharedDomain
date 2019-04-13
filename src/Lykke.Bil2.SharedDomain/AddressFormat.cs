using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.Bil2.SharedDomain
{
    /// <summary>
    /// Particular format of an address.
    /// </summary>
    [PublicAPI]
    public sealed class AddressFormat : IEquatable<AddressFormat>
    {
        /// <summary>
        /// Address in the particular format.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; }

        /// <summary>
        /// Optional.
        /// Name of the format. Can be omitted for one item in the list.
        /// Omitted value will be interpreted as default address format.
        /// </summary>
        [JsonProperty("formatName")]
        public string FormatName { get; }

        /// <summary>
        /// Particular format of an address.
        /// </summary>
        /// <param name="address">Address in the particular format.</param>
        /// <param name="formatName">
        /// Optional.
        /// Name of the format. Can be omitted for one item in the list.
        /// Omitted value will be interpreted as default address format.
        /// </param>
        public AddressFormat(Address address, string formatName = null)
        {
            if (formatName != null && string.IsNullOrWhiteSpace(formatName))
                throw new ArgumentException("Should be either null or not empty string", nameof(formatName));

            Address = address ?? throw new ArgumentNullException(nameof(address));
            FormatName = formatName;
        }

        public override string ToString()
        {
            return $"{FormatName}:{Address}";
        }

        public bool Equals(AddressFormat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(Address, other.Address) && string.Equals(FormatName, other.FormatName);
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
            return Equals((AddressFormat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0) * 397) ^ (FormatName != null ? FormatName.GetHashCode() : 0);
            }
        }

        public static bool operator ==(AddressFormat a, AddressFormat b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(AddressFormat a, AddressFormat b)
        {
            return !Equals(a, b);
        }
    }
}
