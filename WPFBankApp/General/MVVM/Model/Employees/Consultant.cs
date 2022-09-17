using WPFBankApp.General.MVVM.Model.Access;
using WPFBankApp.General.MVVM.Model.Access.Parameters;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.MVVM.Model.Employees;

public class Consultant : Employee
{
    public Consultant()
    {
        DataAccess = new AccessValidator(
            new CommandAccess
            {
                AddAccountCommand = false,
                EditAccountCommand = true,
                RemoveAccountCommand = false
            }, 
            new EditAccess()
            {
                FirstName = false,
                LastName = false, 
                PhoneNumber = true,
                Passport = false
            });
    }

    public override AccountInfo GetAccountInfo(Account account)
    {
        var accountInfo = new AccountInfo(account)
        {
            Passport = "****-******"
        };
        return accountInfo;
    }
}