using System;
using WPFBankApp.General.MVVM.Model.Accounts.Base;
using WPFBankApp.General.MVVM.Model.Accounts.ProtectedData;

namespace WPFBankApp.General.MVVM.Model.Accounts;

public class Account : Person
{
    #region Fields

    private static int _staticId;
    private static int NextId()
    {
        return _staticId++;
    }

    #endregion

    #region Props

    public int Id { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Passport Passport { get; set; }
    public DateTime AddTime { get; set; } = DateTime.Now;
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    #endregion

    #region Declare
    static Account()
    {
        _staticId = 1;
    }

    public Account() { }

    public Account(string firstName, string lastName, PhoneNumber phoneNumber, Passport passport)
        : base(firstName, lastName)
    {
        PhoneNumber = phoneNumber;
        Passport = passport;
    }

    #endregion
}