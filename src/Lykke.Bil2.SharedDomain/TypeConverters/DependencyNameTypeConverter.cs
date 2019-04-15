namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class DependencyNameTypeConverter : BaseStringValueTypeConverter<DependencyName>
    {
        protected override DependencyName Create(string value) => new DependencyName(value);
    }
}