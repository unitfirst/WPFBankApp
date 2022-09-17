using System.Windows;
using WPFBankApp.General.Core.Commands.Base;

namespace WPFBankApp.General.Core.Commands.Toolbar
{
    public class ShutDownCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}