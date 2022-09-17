using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.MVVM.Model.Employees;

public class Consultant : Employee
{
    public override AccountInfo GetAccountInfo(Account client)
    {
        throw new System.NotImplementedException();
    }
}