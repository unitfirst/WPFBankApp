using System.Windows;
using WPFBankApp.General.MVVM.View.LoginWindow;
using WPFBankApp.General.MVVM.ViewModel;
using WPFBankApp.General.MVVM.ViewModel.LoginWindowVM;

namespace WPFBankApp.General
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new LoginWindow { DataContext = new LoginViewModel() }.Show();
        }
    }
}