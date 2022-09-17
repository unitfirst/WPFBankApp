using WPFBankApp.General.MVVM.Model.Access;
using WPFBankApp.General.MVVM.Model.Accounts;

namespace WPFBankApp.General.MVVM.Model.Employees.Base;

public abstract class Employee
{
    protected AccessValidator DataAccess { get; set; }

    public abstract AccountInfo GetAccountInfo(Account client);
}