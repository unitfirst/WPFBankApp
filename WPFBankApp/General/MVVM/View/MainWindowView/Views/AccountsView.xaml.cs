using System.Windows.Controls;
using WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

namespace WPFBankApp.General.MVVM.View.MainWindowView.Views;

public partial class AccountsView : UserControl
{
    public AccountsView()
    {
        InitializeComponent();
        DataContext = new AccountsViewModel();
    }
}