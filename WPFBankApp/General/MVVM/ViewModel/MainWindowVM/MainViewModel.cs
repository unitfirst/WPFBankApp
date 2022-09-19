using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using WPFBankApp.AppFiles.Core.Commands;
using WPFBankApp.General.Core.Settings;
using WPFBankApp.General.Core.Settings.Paths;
using WPFBankApp.General.Data;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;
using WPFBankApp.General.MVVM.ViewModel.Base;
using WPFBankApp.General.Service;

namespace WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

public class MainViewModel : ViewModelBase
{
    public IConfig Config;
    public Action UpdateClientsList;

    public MainViewModel()
    {
    }

    public MainViewModel(Employee employee)
    {
        Config = new Config();
        AccountsPath = Config.Load();
        Employee = employee;
        Bank = new Bank("niBank", new Repository(AccountsPath.FilePath), employee);
        
        Accounts = new ObservableCollection<Account>();

        UpdateList();

        #region Views

        AccountsVm = new AccountsViewModel(this, Accounts);
        NewAccountVm = new NewAccountViewModel(this);
        SettingsVm = new SettingsViewModel();
        AboutVm = new AboutViewModel();

        CurrentView = AccountsVm;

        #endregion

        #region Change view commands

        ShowAccountsView = new RelayCommand(OnShowAccountsViewExecuted, CanShowAccountsViewExecute);
        ShowSettingsView = new RelayCommand(OnShowSettingsViewExecuted, CanShowSettingsViewExecute);
        ShowNewAccountView = new RelayCommand(OnShowNewAccountViewExecuted, CanShowNewAccountViewExecute);
        ShowAboutView = new RelayCommand(OnShowAboutViewExecuted, CanShowAboutViewExecute);

        #endregion
    }

    private void UpdateList()
    {
        Debug.WriteLine("---------CALL UpdateList---------");

        Accounts.Clear();
        foreach (var item in Bank.GetAccountsInfo())
        {
            Accounts.Add(item);
            Debug.WriteLine("---------UPDATING LIST---------");
            Debug.WriteLine($"{item.Id} " +
                            $"{item.FirstName} " +
                            $"{item.LastName} " +
                            $"{item.PhoneNumber} " +
                            $"{item.Passport}");
        }

        //EnableEditClient = MainVm.Employee.DataAccess.Commands.EditClient && Clients.Count > 0;
    }

    #region Current View

    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Fields

    private AccountsViewModel AccountsVm { get; }
    private SettingsViewModel SettingsVm { get; }
    private NewAccountViewModel NewAccountVm { get; }
    private AboutViewModel AboutVm { get; }
    public AccountsPath AccountsPath { get; }
    
    public Repository Repository { get; set; }
    public ObservableCollection<Account> Accounts { get; set; }
    public Employee Employee { get; set; }
    public Bank Bank { get; }

    #endregion

    #region Commands

    #region ShowAccountsView

    public ICommand ShowAccountsView { get; }

    private bool CanShowAccountsViewExecute(object p)
    {
        return true;
    }

    private void OnShowAccountsViewExecuted(object p)
    {
        CurrentView = AccountsVm;
    }

    #endregion

    #region ShowSettingsView

    public ICommand ShowSettingsView { get; }

    private bool CanShowSettingsViewExecute(object p)
    {
        return true;
    }

    private void OnShowSettingsViewExecuted(object p)
    {
        CurrentView = SettingsVm;
    }

    #endregion

    #region ShowSettingsView

    public ICommand ShowNewAccountView { get; }

    private bool CanShowNewAccountViewExecute(object p)
    {
        return true;
    }

    private void OnShowNewAccountViewExecuted(object p)
    {
        CurrentView = NewAccountVm;
    }

    #endregion

    #region ShowAboutView

    public ICommand ShowAboutView { get; }

    private bool CanShowAboutViewExecute(object p)
    {
        return true;
    }

    private void OnShowAboutViewExecuted(object p)
    {
        CurrentView = AboutVm;
    }

    #endregion

    #endregion
}