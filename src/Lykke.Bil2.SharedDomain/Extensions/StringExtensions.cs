using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain.Extensions
{
    [PublicAPI]
    public static class StringExtensions
    {
        /// <summary>
        /// Encodes the string as Base58 string
        /// </summary>
        public static Base58String ToBase58(this string value)
        {
            return Base58String.Encode(value);
        }
    }
}
