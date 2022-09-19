using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using WPFBankApp.AppFiles.Core.Commands;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.ViewModel.Base;

namespace WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

public class AccountsViewModel : ViewModelBase
{
    //private Command _updateAccountCommand;
    //private Command _removeAccountCommand;

    public readonly Action UpdateAccountsList;
    public ObservableCollection<Account> Accounts { get; set; }
    public MainViewModel MainVm;

    public AccountsViewModel()
    {
    }

    public AccountsViewModel(MainViewModel mainVm, ObservableCollection<Account> accounts)
    {
        MainVm = mainVm;
        Accounts = accounts;
        foreach (var item in Accounts)
        {
            Debug.WriteLine($"{item.Id} " +
                            $"{item.FirstName} " +
                            $"{item.LastName} " +
                            $"{item.PhoneNumber} " +
                            $"{item.Passport}");
        }

        //UpdateAccountCommand = new RelayCommand(OnUpdateAccountCommandExecuted, CanUpdateAccountCommandExecute);
        RemoveAccountCommand = new RelayCommand(OnRemoveAccountCommandExecuted, CanRemoveAccountCommandExecute);

        _selectedIndex = 0;
    }

    #region Selected

    #region SelectedAccount

    private AccountInfo _selectedAccount;

    public AccountInfo SelectedAccount
    {
        get => _selectedAccount;
        set
        {
            _selectedAccount = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region SelectedIndex

    private int _selectedIndex;

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #endregion

    #region Commands

    #region RemoveAccountCommand

    public ICommand RemoveAccountCommand { get; }

    private void OnRemoveAccountCommandExecuted(object p)
    {
        if (SelectedAccount is null) return;

        MainVm.Bank.RemoveAccount(SelectedAccount);
        UpdateAccountsList();
    }

    private bool CanRemoveAccountCommandExecute(object p) => true;

    #endregion

    /*#region UpdateAccountCommand
    public ICommand UpdateAccountCommand { get; }

    private void OnUpdateAccountCommandExecuted(object p)
    {
        var client = new Client(
            new PhoneNumber(_phoneNumber), 
            _enablePassportData ? new PassportData(int.Parse(_passportSerie), int.Parse(_passportNumber)) : 
                new PassportData(_currentClientInfo.PassportData.Serie, _currentClientInfo.PassportData.Number), 
            _firstName, _lastName, _middleName);
        if (_currentClientInfo.Id == 0) // новый клиент
        {
            _bank.AddClient(client);
        }
        else
        {
            client.Id = _currentClientInfo.Id;
            _bank.EditClient(client);
        }
        
        _clientsVm.UpdateClientsList.Invoke();
        
        UpdateAccountsList();
    }

    private bool CanUpdateAccountCommandExecute(object p) => true;
    #endregion#1#*/

    /*public Command RemoveAccountCommand
    {
        get
        {
            return _removeAccountCommand ??= new RelayCommand(obj =>
                {
                    if (obj is Account account) Accounts.Remove(account);
                },
                obj => Accounts.Count > 0);
        }
    }*/

    /*public ICommand UpdateAccountCommand
    {
        get
        {
            return _updateAccountCommand ??= new RelayCommand(obj =>
                {
                    if (obj is Account account)
                    {
                        var tempAccount = SelectedAccount;
                        var index = Accounts.IndexOf(SelectedAccount);

                        Accounts.Remove(SelectedAccount);
                        Accounts.Insert(index, tempAccount);
                        SelectedAccount = tempAccount;
                    }
                },
                obj => Accounts.Count > 0);
        }
    }*/

    #endregion

    private void UpdateList()
    {
        Accounts.Clear();
        foreach (var item in MainVm.Bank.GetAccountsInfo())
        {
            Accounts.Add(item);
        }

        //SelectedIndex = selectedIndex;

        //EnableEditClient = MainVm.Employee.DataAccess.Commands.EditClient && Clients.Count > 0;
    }
}