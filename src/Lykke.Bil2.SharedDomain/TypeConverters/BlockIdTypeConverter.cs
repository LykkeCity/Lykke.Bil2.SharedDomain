namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class BlockIdTypeConverter : BaseStringValueTypeConverter<BlockId>
    {
        protected override BlockId Create(string value) => new BlockId(value);
    }
}