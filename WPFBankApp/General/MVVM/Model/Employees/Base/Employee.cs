using WPFBankApp.General.MVVM.Model.Access;
using WPFBankApp.General.MVVM.Model.Accounts;

namespace WPFBankApp.General.MVVM.Model.Employees.Base;

public abstract class Employee
{
    public AccessValidator DataAccess { get; protected set; }

    public abstract AccountInfo GetAccountInfo(Account client);
}