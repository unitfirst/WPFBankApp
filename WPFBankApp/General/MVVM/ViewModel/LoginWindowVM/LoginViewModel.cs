using System.Windows;
using System.Windows.Input;
using WPFBankApp.AppFiles.Core.Commands;
using WPFBankApp.General.MVVM.Model.Employees;
using WPFBankApp.General.MVVM.Model.Employees.Base;
using WPFBankApp.General.MVVM.ViewModel.Base;
using WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

namespace WPFBankApp.General.MVVM.ViewModel.LoginWindowVM;

public class LoginViewModel : ViewModelBase
{
    #region Commands

    #region LoginAsConsultantCommand

    public ICommand LoginAsConsultantCommand { get; }
    private void OnLoginAsConsultantCommandExecuted(object p) { OpenMainWindow(new Consultant(), p); }
    private bool CanLoginAsConsultantCommandExecute(object p) => true;

    #endregion

    #region LoginAsManagerCommand

    public ICommand LoginAsManagerCommand { get; }
    private void OnLoginAsManagerCommandExecuted(object p) { OpenMainWindow(new Manager(), p); }
    private bool CanLoginAsManagerCommandExecute(object p) => true;

    #endregion

    private void OpenMainWindow(Employee employee, object p)
    {
        var mainWindow = new MainWindow
        {
            DataContext = new MainViewModel(employee)
        };
        mainWindow.Show();
            
        CloseThisWindow(p);
    }

    private void CloseThisWindow(object p)
    {
        if (p is Window window) window.Close();
    }

    #endregion

    public LoginViewModel()
    {
        LoginAsConsultantCommand = new RelayCommand(OnLoginAsConsultantCommandExecuted, CanLoginAsConsultantCommandExecute);
        LoginAsManagerCommand = new RelayCommand(OnLoginAsManagerCommandExecuted, CanLoginAsManagerCommandExecute);
    }
}