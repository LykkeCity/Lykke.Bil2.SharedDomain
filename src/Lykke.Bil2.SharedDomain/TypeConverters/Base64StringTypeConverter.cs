﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace Lykke.Bil2.SharedDomain.TypeConverters
{
    internal class Base64StringTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType)
        {
            return sourceType == typeof(string);
        }
        
        public override bool CanConvertTo(
            ITypeDescriptorContext context,
            Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            return value != null ? new Base64String((string) value) : null;
        }
        
        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            return value?.ToString();
        }
    }
}
