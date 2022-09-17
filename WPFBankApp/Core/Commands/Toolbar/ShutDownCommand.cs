using System.Windows;
using WPFBankApp.Core.Commands.Base;

namespace WPFBankApp.Core.Commands.Toolbar
{
    public class ShutDownCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}