using WPFBankApp.General.MVVM.Model.Access.Parameters;

namespace WPFBankApp.General.MVVM.Model.Access;

public class AccessValidator
{
    public CommandAccess CommandAccess;
    public EditAccess EditAccess;

    public AccessValidator(CommandAccess commands, EditAccess editFields)
    {
        CommandAccess = commands;
        EditAccess = editFields;
    }
}