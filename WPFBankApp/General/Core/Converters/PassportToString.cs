using System;
using System.Globalization;
using System.Windows.Data;
using WPFBankApp.General.MVVM.Model.Accounts.ProtectedData;

namespace WPFBankApp.General.Core.Converters;

public class PassportToString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Passport data) return null;
        return data.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}