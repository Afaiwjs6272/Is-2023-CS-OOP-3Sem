using Application.Contracts.Admin;
using Spectre.Console;

namespace Presentation.Commands;

public class AddAccountCommand : ICommand
{
    private IAdminService _adminService;

    public AddAccountCommand(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool Execute()
    {
        int pin = AnsiConsole.Ask<int>("Enter pin for new account:");
        int accountId = _adminService.AddAccount(pin);
        AnsiConsole.WriteLine($"New account id: {accountId}");
        return true;
    }
}