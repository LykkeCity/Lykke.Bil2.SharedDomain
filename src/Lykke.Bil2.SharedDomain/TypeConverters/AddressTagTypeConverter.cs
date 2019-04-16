namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class AddressTagTypeConverter : BaseStringValueTypeConverter<AddressTag>
    {
        protected override AddressTag Create(string value) => new AddressTag(value);
    }
}