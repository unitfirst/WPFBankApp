using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WPFBankApp.General.Data.Interface;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Accounts.ProtectedData;

namespace WPFBankApp.General.Data;

public class Repository : IRepository
{
    private string _path;
    private List<Account> _records;
    public List<Account> Records => _records;
    public IEnumerable<Account> GetAllRecords() => Records;
    public int Count => _records.Count;

    public Repository(string path)
    {
        _path = path;

        if (File.Exists(_path))
        {
            LoadFile(_path);
        }
        else
        {
            File.Create(_path).Dispose();
            AddTestRecord();
        }
    }

    public Account GetRecordById(int id)
    {
        throw new System.NotImplementedException();
    }

    private List<Account> LoadFile(string path)
    {
        using (var reader = new StreamReader(_path))
        {
            _records = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
            if (string.IsNullOrEmpty(_path) || _records is null)
            {
                AddTestRecord();
                return _records;
            }

            return _records;
        }
    }

    public void SaveFile(string path)
    {
        var file = JsonConvert.SerializeObject(_records.ToArray());
        File.WriteAllText(_path, file);
    }

    public void InsertRecord(Account account)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteRecord(int id)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateRecord(Account account)
    {
        throw new System.NotImplementedException();
    }

    public void ClearAllRecords()
    {
        throw new System.NotImplementedException();
    }

    private void AddTestRecord()
    {
        _records = new List<Account>();

        var testRecord = new Account()
        {
            FirstName = "Hideo",
            LastName = "Kodzima",
            PhoneNumber = new PhoneNumber("+70000000000"),
            Passport = new Passport(0000000000)
        };

        _records.Add(testRecord);
    }

    public IEnumerator<Account> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return Records[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}