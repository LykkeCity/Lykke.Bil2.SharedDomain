namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class AssetIdTypeConverter : BaseStringValueTypeConverter<AssetId>
    {
        protected override AssetId Create(string value) => new AssetId(value);
    }
}