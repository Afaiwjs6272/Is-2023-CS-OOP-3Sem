using Application.Tools;
using Presentation.Commands;

namespace Presentation.CommandsSupport;

public static class CommandHandler
{
    public static bool Handle(ICommand command)
    {
        if (command == null)
        {
            throw new CustomException("Null command");
        }

        return command.Execute();
    }
}