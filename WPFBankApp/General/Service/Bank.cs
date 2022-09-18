using System.Collections.Generic;
using WPFBankApp.General.Data.Interface;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;

namespace WPFBankApp.General.Service;

public class Bank
{
    private readonly Employee _employee;

    private string _name;

    public Bank(string name, IRepository repository, Employee employee)
    {
        _name = name;
        _employee = employee;
    }

    public IRepository Repository { get; set; }

    public IEnumerable<AccountInfo> GetAccountsInfo()
    {
        var list = new List<AccountInfo>();
        foreach (var item in Repository) list.Add(_employee.GetAccountInfo(item));

        return list;
    }
}