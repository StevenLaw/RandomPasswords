﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace RandomPasswords.View.Converters
{
    public class ProfileTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string profile && parameter is string pString)
            {
                return profile == pString;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Default";
        }
    }
}