using System.Collections.Generic;
using WPFBankApp.General.MVVM.Model.Accounts;

namespace WPFBankApp.General.Data.Interface;

public interface IRepository : IEnumerable<Account>
{
    public int Count { get; }

    void InsertRecord(Account account);

    void DeleteRecord(int id);

    void UpdateRecord(Account account);

    void ClearAllRecords();

    Account GetRecordById(int id);

    IEnumerable<Account> GetAllRecords();
}