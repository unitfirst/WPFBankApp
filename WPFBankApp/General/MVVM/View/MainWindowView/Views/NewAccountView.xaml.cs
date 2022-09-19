using System.Windows.Controls;
using WPFBankApp.General.MVVM.ViewModel.MainWindowVM;

namespace WPFBankApp.General.MVVM.View.MainWindowView.Views;

public partial class NewAccountView : UserControl
{
    public NewAccountView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}