using WPFBankApp.General.MVVM.Model.Access.Parameters;

namespace WPFBankApp.General.MVVM.Model.Access;

public class AccessValidator
{
    private CommandAccess _commands;
    private EditAccess _editFields;
    
    public AccessValidator(CommandAccess commands, EditAccess editFields)
    {
        _commands = commands;
        _editFields = editFields;
    }
}