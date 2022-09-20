using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFBankApp.AppFiles.Core.Commands;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.ViewModel.Base;

namespace WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

public class AccountsViewModel : ViewModelBase
{
    public MainViewModel MainVm;
    public Action UpdateAccountsList;

    public AccountsViewModel()
    {
    }

    public AccountsViewModel(MainViewModel mainVm)
    {
        MainVm = mainVm;
        Accounts = MainVm.Accounts;

        RemoveAccountCommand = new RelayCommand(OnRemoveAccountExecuted, CanRemoveAccountExecute);
        UpdateAccountCommand = new RelayCommand(OnUpdateAccountCommandExecuted, CanUpdateAccountCommandExecute);
    }

    public ObservableCollection<Account> Accounts { get; set; }

    public void UpdateList()
    {
        Accounts.Clear();
        foreach (var item in MainVm.Bank.GetAccountsInfo()) Accounts.Add(item);

        SelectedIndex = _selectedIndex;

        //EnableEditClient = MainVm.Employee.DataAccess.Commands.EditClient && Clients.Count > 0;
    }

    public void BindingValues()
    {
        _firstNameToBinding = SelectedAccount.FirstName ?? string.Empty;
        _lastNameToBinding = SelectedAccount.LastName ?? string.Empty;
        _phoneNumberToBinding = SelectedAccount.PhoneNumber.ToString();
        _passportToBinding = SelectedAccount.Passport ?? string.Empty;
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

    private void OnRemoveAccountExecuted(object p)
    {
        if (SelectedAccount is null) return;

        MainVm.Bank.RemoveAccount(SelectedAccount);
        UpdateList();
    }

    private bool CanRemoveAccountExecute(object p)
    {
        return true;
    }

    #endregion

    #region UpdateAccountCommand

    public ICommand UpdateAccountCommand { get; }

    private void OnUpdateAccountCommandExecuted(object p)
    {
        Account tempAccount = SelectedAccount;
        var index = Accounts.IndexOf(SelectedAccount);

        Accounts.Remove(SelectedAccount);
        Accounts.Insert(index, tempAccount);
        SelectedAccount = (AccountInfo)tempAccount;

        UpdateList();
    }

    private bool CanUpdateAccountCommandExecute(object p)
    {
        return true;
    }

    #endregion

    #endregion

    #region AccountToBinding

    #region FirstNameToBinding

    private string _firstNameToBinding;

    public string FirstNameToBinding
    {
        get => _firstNameToBinding;
        set => Set(ref _firstNameToBinding, value);
    }

    #endregion

    #region LastNameToBinding

    private string _lastNameToBinding;

    public string LastNameToBinding
    {
        get => _lastNameToBinding;
        set => Set(ref _lastNameToBinding, value);
    }

    #endregion

    #region PhoneNumberToBinding

    private string _phoneNumberToBinding;

    public string PhoneNumberToBinding
    {
        get => _phoneNumberToBinding;
        set => Set(ref _phoneNumberToBinding, value);
    }

    #endregion

    #region PassportToBindig

    private string _passportToBinding;

    public string PassportToBinding
    {
        get => _passportToBinding;
        set => Set(ref _passportToBinding, value);
    }

    #endregion

    #endregion
}