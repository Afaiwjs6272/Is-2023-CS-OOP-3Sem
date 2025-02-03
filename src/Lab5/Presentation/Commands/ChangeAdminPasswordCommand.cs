using Application.Contracts.Admin;
using Spectre.Console;

namespace Presentation.Commands;

public class ChangeAdminPasswordCommand : ICommand
{
    private IAdminService _adminService;

    public ChangeAdminPasswordCommand(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool Execute()
    {
        string password = AnsiConsole.Ask<string>("Enter new password:");
        AnsiConsole.WriteLine(_adminService.ChangeAdminPassword(password)
            ? "Password changed."
            : "Unsuitable password value.");
        return true;
    }
}