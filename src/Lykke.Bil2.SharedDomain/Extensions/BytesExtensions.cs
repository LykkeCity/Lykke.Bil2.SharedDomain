using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain.Extensions
{
    [PublicAPI]
    public static class BytesExtensions
    {
        public static Base64String EncodeToBase64(this byte[] value)
        {
            return Base64String.Encode(value);
        }
    }
}
