using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFBankApp.General.MVVM.ViewModel.Base;

namespace WPFBankApp.General.MVVM.Model.Accounts.Base;

public class Person : ViewModelBase
{
    #region Fields

    private string _firstName;
    private string _lastName;

    #endregion

    #region Props

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName == value) return;

            _firstName = value;
            OnPropertyChanged(FirstName);
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (_lastName == value) return;

            _lastName = value;
            OnPropertyChanged(LastName);
        }
    }

    #endregion

    #region Declare

    public Person() { }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #endregion

    #region OnPropertyChanged

    public new event PropertyChangedEventHandler PropertyChanged;

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}