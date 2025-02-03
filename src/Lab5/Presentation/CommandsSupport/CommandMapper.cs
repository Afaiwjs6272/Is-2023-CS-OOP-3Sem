using Application.Tools;
using Presentation.Commands;

namespace Presentation.CommandsSupport;

public class CommandMapper
{
    private Dictionary<string, ICommand> _commands;
    public CommandMapper()
    {
        _commands = new Dictionary<string, ICommand>();
    }

    public void AddCommand(string selection, ICommand command)
    {
        _commands.Add(selection, command);
    }

    public bool ExecuteCommand(string selection)
    {
        if (_commands.TryGetValue(selection, out ICommand? command))
        {
            return CommandHandler.Handle(command);
        }
        else
        {
            throw new CustomException("Command not registered in mapper");
        }
    }
}