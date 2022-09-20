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
    private readonly string _path;

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
            LoadFile(_path);
        }
    }

    public List<Account> Records { get; private set; }

    public IEnumerable<Account> GetAllRecords()
    {
        return Records;
    }

    public int Count => Records.Count;

    public Account GetRecordById(int id)
    {
        throw new NotImplementedException();
    }

    public void InsertRecord(Account account)
    {
        throw new NotImplementedException();
    }

    public void DeleteRecord(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateRecord(Account account)
    {
        throw new NotImplementedException();
    }

    public void ClearAllRecords()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Account> GetEnumerator()
    {
        for (var i = 0; i < Count; i++) yield return Records[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private List<Account> LoadFile(string path)
    {
        using (var reader = new StreamReader(_path))
        {
            Records = JsonConvert.DeserializeObject<List<Account>>(reader.ReadToEnd());
            if (string.IsNullOrEmpty(_path) || Records is null)
            {
                AddTestRecord();

                return Records;
            }

            return Records;
        }
    }

    public void SaveFile(string path)
    {
        var file = JsonConvert.SerializeObject(Records.ToArray());
        File.WriteAllText(_path, file);
    }

    private void AddTestRecord()
    {
        Records = new List<Account>();

        var testRecord = new Account
        {
            FirstName = "Hideo",
            LastName = "Kodzima",
            PhoneNumber = new PhoneNumber("+70000000000"),
            Passport = new Passport(1234567890)
        };

        Records.Add(testRecord);
        SaveFile(_path);
    }
}