using System.Windows.Input;
using WPFBankApp.AppFiles.Core.Commands;
using WPFBankApp.General.MVVM.Model.Accounts;
using WPFBankApp.General.MVVM.Model.Employees.Base;
using WPFBankApp.General.MVVM.ViewModel.Base;

namespace WPFBankApp.General.MVVM.ViewModel;

    public class MainViewModel : ViewModelBase
    {
        #region Current View

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region View fields

        private AccountsViewModel AccountsVm { get; set; }
        private SettingsViewModel SettingsVm { get; set; }
        private NewAccountViewModel NewAccountVm { get; set; }
        private AboutViewModel AboutVm { get; set; }
        public Account Account { get; set; }
        public Employee Employee { get; set; }


        #endregion

        #region Commands

        #region ShowAccountsView

        public ICommand ShowAccountsView { get; }
        private bool CanShowAccountsViewExecute(object p) => true;
        private void OnShowAccountsViewExecuted(object p)
        {
            CurrentView = AccountsVm;
        }

        #endregion

        #region ShowSettingsView

        public ICommand ShowSettingsView { get; }
        private bool CanShowSettingsViewExecute(object p) => true;
        private void OnShowSettingsViewExecuted(object p)
        {
            CurrentView = SettingsVm;
        }

        #endregion

        #region ShowSettingsView

        public ICommand ShowNewAccountView { get; }
        private bool CanShowNewAccountViewExecute(object p) => true;
        private void OnShowNewAccountViewExecuted(object p)
        {
            CurrentView = NewAccountVm;
        }

        #endregion

        #region ShowAboutView

        public ICommand ShowAboutView { get; }
        private bool CanShowAboutViewExecute(object p) => true;
        private void OnShowAboutViewExecuted(object p)
        {
            CurrentView = AboutVm;
        }

        #endregion

        #endregion

        public MainViewModel() { }
        public MainViewModel(Employee employee)
        {
            #region Views

            AccountsVm = new AccountsViewModel();
            NewAccountVm = new NewAccountViewModel();
            SettingsVm = new SettingsViewModel();
            AboutVm = new AboutViewModel();

            CurrentView = AccountsVm;
            Employee = employee;

            #endregion

            #region Change view commands

            ShowAccountsView = new RelayCommand(OnShowAccountsViewExecuted, CanShowAccountsViewExecute);
            ShowSettingsView = new RelayCommand(OnShowSettingsViewExecuted, CanShowSettingsViewExecute);
            ShowNewAccountView = new RelayCommand(OnShowNewAccountViewExecuted, CanShowNewAccountViewExecute);
            ShowAboutView = new RelayCommand(OnShowAboutViewExecuted, CanShowAboutViewExecute);

            #endregion
        }
    }