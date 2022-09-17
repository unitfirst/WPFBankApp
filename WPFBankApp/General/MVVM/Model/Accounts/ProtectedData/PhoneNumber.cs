using System;
using System.Text.RegularExpressions;
using WPFBankApp.General.MVVM.ViewModel.Base;

namespace WPFBankApp.General.MVVM.Model.Accounts.ProtectedData;

public class PhoneNumber : ViewModelBase
{
    private string _number;

    public string Number
    {
        get => _number;
        set
        {
            if (_number == value) return;

            _number = value;
            OnPropertyChanged(Number);
        }
    }

    #region Declare

    public PhoneNumber() { }

    public PhoneNumber(string number)
    {
        SetNumber(number);
    }

    #endregion

    #region Methods

    public static bool IsPhoneNumber(string number)
    {
        var result = Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        return result;
    }

    private void SetNumber(string number)
    {
        CheckNumber(number);
        _number = number;
    }

    private void CheckNumber(string number)
    {
        if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException($"Number \"{nameof(number)}\" is not correct");
        }

        if (!IsPhoneNumber(number))
        {
            throw new ArgumentException($"\"{nameof(number)}\" is not a phone number");
        }
    }

    public override string ToString()
    {
        return $"{Number}";
    }

    #endregion

}