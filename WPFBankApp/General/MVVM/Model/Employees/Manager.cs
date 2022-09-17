using WPFBankApp.General.MVVM.Model.Access;
using WPFBankApp.General.MVVM.Model.Access.Parameters;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.MVVM.Model.Employees;

internal class Manager : Employee
{
    public Manager()
    {
        DataAccess = new AccessValidator(
            new CommandAccess
            {
                AddAccountCommand = true,
                EditAccountCommand = true,
                RemoveAccountCommand = true
            }, 
            new EditAccess()
            {
                FirstName = true,
                LastName = true, 
                PhoneNumber = true,
                Passport = true
            });
    }

    public override AccountInfo GetAccountInfo(Account account)
    {
        var accountInfo = new AccountInfo(account)
        {
            Passport = account.Passport.ToString()
        };
        return accountInfo;
    }
}