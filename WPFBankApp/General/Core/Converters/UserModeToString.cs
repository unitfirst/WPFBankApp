using System;
using System.Globalization;
using System.Windows.Data;
using WPFBankApp.General.MVVM.Model.Employees;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.Converters
{
    public class UserModeToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Employee employee) return null;
            return employee switch
            {
                Consultant _ => "Consultant",
                Manager _ => "Manager",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}