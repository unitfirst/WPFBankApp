using System.Windows;
using WPFBankApp.General.Core.Commands.Base;

namespace WPFBankApp.General.Core.Commands.Toolbar
{
    public class MinimizeWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            foreach (var item in Application.Current.Windows)
            {
                ((Window)item).WindowState = ((Window)item).WindowState == WindowState.Minimized
                    ? WindowState.Normal
                    : WindowState.Minimized;
            }
        }
    }
}