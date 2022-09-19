namespace WPFBankApp.General.Core.Settings.Paths;

public class AccountsPath
{
    private string _path;

    public AccountsPath()
    {
        _path = string.Empty;
    }

    public string FilePath
    {
        get
        {
            if (string.IsNullOrEmpty(_path)) _path = @"records.json";
            return _path;
        }
        set => _path = value;
    }
}
