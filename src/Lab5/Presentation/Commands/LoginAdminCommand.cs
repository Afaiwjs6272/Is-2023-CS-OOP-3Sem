using Application.Contracts.Admin;
using Spectre.Console;

namespace Presentation.Commands;

public class LoginAdminCommand : ICommand
{
    private IAdminService _adminService;

    public LoginAdminCommand(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool Execute()
    {
        string password = AnsiConsole.Ask<string>("Enter password:");
        try
        {
            if (_adminService.Login(password))
            {
                AnsiConsole.WriteLine("Login complete");
                return true;
            }
            else
            {
                AnsiConsole.WriteLine("Wrong password");
                return false;
            }
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }
}