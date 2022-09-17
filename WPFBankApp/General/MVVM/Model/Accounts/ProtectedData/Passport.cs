namespace WPFBankApp.General.MVVM.Model.Accounts.ProtectedData;

public class Passport : ViewModelBase
{
    private long _passportData;

    public long PassportData
    {
        get => _passportData;
        set
        {
            if (_passportData == value) return;

            _passportData = value;
            OnPropertyChanged(PassportData.ToString());
        }
    }

    #region Declare

    public Passport() { }

    public Passport(int passportData)
    {
        PassportData = passportData;
    }

    #endregion

    #region Values

    public const long MinValue = 1;
    public const long MaxValue = 9999999999;

    #endregion

    #region Methods

    public static bool IsSeries(string input)
    {
        if (!long.TryParse(input, out long value))
            return false;

        if (value < MinValue || value > MaxValue)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"{PassportData}";
    }

    #endregion
}