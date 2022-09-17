namespace WPFBankApp.General.MVVM.Model.Accounts;

public class AccountInfo : Account
{
    public string Passport { get; set; }

    public AccountInfo() { }
    public AccountInfo(Account account)
        : base(account.FirstName, account.LastName, account.PhoneNumber, account.Passport)
    {
        Id = account.Id;
    }
}