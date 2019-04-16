namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class AddressTypeConverter : BaseStringValueTypeConverter<Address>
    {
        protected override Address Create(string value) => new Address(value);
    }
}
