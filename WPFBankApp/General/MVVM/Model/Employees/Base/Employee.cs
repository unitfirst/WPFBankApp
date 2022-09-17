namespace WPFBankApp.General.MVVM.Model.Employees.Base;

public abstract class Employee
{
    public AccessValidator DataAccess { get; protected set; }

    public abstract AccountInfo GetAccountInfo(Account client);
}