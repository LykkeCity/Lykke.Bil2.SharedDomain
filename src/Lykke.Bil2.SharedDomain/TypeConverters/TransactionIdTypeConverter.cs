namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class TransactionIdTypeConverter : BaseStringValueTypeConverter<TransactionId>
    {
        protected override TransactionId Create(string value) => new TransactionId(value);
    }
}
