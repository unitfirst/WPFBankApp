using System.IO;
using Newtonsoft.Json;
using WPFBankApp.General.Core.Settings.Paths;

namespace WPFBankApp.General.Core.Settings;

public class Config : IConfig
{
    private readonly string _path;
    public readonly string BankName;

    public Config()
    {
        BankName = "niBank v2.0";
        _path = @"config.json";
    }

    public Config(string path, string bankName)
    {
        _path = path;
        BankName = bankName;
    }

    public AccountsPath Load()
    {
        if (!File.Exists(_path)) return new AccountsPath();

        using (var reader = new StreamReader(_path))
        {
            return JsonConvert.DeserializeObject<AccountsPath>(reader.ReadToEnd()) ?? new AccountsPath();
        }
    }
}