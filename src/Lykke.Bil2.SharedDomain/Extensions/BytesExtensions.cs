using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain.Extensions
{
    [PublicAPI]
    public static class BytesExtensions
    {
        public static Base58String EncodeToBase58(this byte[] value)
        {
            return Base58String.Encode(value);
        }
    }
}
