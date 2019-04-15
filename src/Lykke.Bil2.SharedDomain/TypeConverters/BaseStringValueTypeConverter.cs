using System;
using System.ComponentModel;
using System.Globalization;
using JetBrains.Annotations;

namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    [PublicAPI]
    public abstract class BaseStringValueTypeConverter<TConcrete> : TypeConverter
        where TConcrete : BaseStringValueType<TConcrete>
    {
        protected abstract TConcrete Create(string value);

        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            return Create((string) value);
        }
    }
}
