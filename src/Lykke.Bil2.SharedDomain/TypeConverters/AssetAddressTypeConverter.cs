namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class AssetAddressTypeConverter : BaseStringValueTypeConverter<AssetAddress>
    {
        protected override AssetAddress Create(string value) => new AssetAddress(value);
    }
}