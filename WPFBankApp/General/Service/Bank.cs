using System.Collections.Generic;
using WPFBankApp.General.Data.Interface;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.Service;

public class Bank
{
    private readonly Employee _employee;

    public Bank(string name, IRepository repository, Employee employee)
    {
        Name = name;
        Repository = repository;
        _employee = employee;

        GetAccountsInfo();
    }

    public List<AccountInfo> GetAccountsInfo()
    {
        var list = new List<AccountInfo>();
        foreach (var item in Repository) list.Add(_employee.GetAccountInfo(item));

        return list;
    }

    public void RemoveAccount(Account account)
    {
        Repository.DeleteRecord(account.Id);
    }

    #region Props

    public string Name { get; }
    public IRepository Repository { get; set; }

    #endregion
}