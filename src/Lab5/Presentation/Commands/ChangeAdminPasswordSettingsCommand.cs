using Application.Contracts.Admin;
using Application.Tools;
using Spectre.Console;

namespace Presentation.Commands;

public class ChangeAdminPasswordSettingsCommand : ICommand
{
    private IAdminService _adminService;

    public ChangeAdminPasswordSettingsCommand(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool Execute()
    {
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices("Add/Edit [blue]max[/] number of characters constraint", "Add/Edit [blue]exact[/] number of characters constraint", "Exit"));
        string newPassword, selection4;
        int maxChar = 0, exactChar = 0;
        bool exit = false;
        switch (selection)
        {
            case "Add/Edit [blue]max[/] number of characters constraint":
                maxChar = AnsiConsole.Ask<int>("Enter max number of characters constraint:");
                selection4 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .AddChoices("Add/Edit [blue]exact[/] number of characters constraint", "Apply choice"));
                switch (selection4)
                {
                    case "Add/Edit [blue]exact[/] number of characters constraint":
                        exactChar = AnsiConsole.Ask<int>("Enter exact number of characters constraint:");
                        break;
                    case "Apply choice":
                        break;
                }

                break;
            case "Add/Edit [blue]exact[/] number of characters constraint":
                exactChar = AnsiConsole.Ask<int>("Enter exact number of characters constraint:");
                selection4 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .AddChoices("Add/Edit [blue]max[/] number of characters constraint", "Apply choice"));
                switch (selection4)
                {
                    case "Add/Edit [blue]max[/] number of characters constraint":
                        maxChar = AnsiConsole.Ask<int>("Enter max number of characters constraint:");
                        break;
                    case "Apply choice":
                        break;
                }

                break;
            case "Exit":
                exit = true;
                break;
        }

        if (!exit)
        {
            newPassword = AnsiConsole.Ask<string>("Enter new password:");
            try
            {
                _adminService.ChangeAdminPasswordSettings(newPassword, maxChar, exactChar);
            }
            catch (CustomException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return true;
    }
}