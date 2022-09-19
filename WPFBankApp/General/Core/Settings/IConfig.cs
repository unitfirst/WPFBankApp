using WPFBankApp.General.Core.Settings.Paths;

namespace WPFBankApp.General.Core.Settings;

public interface IConfig
{
    public AccountsPath Load();
}