using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain.Extensions
{
    [PublicAPI]
    public static class StringExtensions
    {
        /// <summary>
        /// Encodes the string as Base64 string
        /// </summary>
        public static Base64String ToBase64(this string value)
        {
            return Base64String.Encode(value);
        }
    }
}
