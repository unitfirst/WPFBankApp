using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.MVVM.Model.Employees;

internal class Manager : Employee
{
    public override AccountInfo GetAccountInfo(Account client)
    {
        throw new System.NotImplementedException();
    }
}