﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class Base58StringTypeConverter : TypeConverter
    {
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
            return new Base58String((string) value);
        }
    }
}
