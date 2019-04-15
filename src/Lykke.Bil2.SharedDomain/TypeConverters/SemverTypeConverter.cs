namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class SemverTypeConverter : BaseStringValueTypeConverter<Semver>
    {
        protected override Semver Create(string value) => new Semver(value);
    }
}