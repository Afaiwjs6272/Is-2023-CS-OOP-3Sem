using Application.Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Commands;

public class LoginAccountCommand : ICommand
{
    private IAccountService _accountService;

    public LoginAccountCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        int accountId = AnsiConsole.Ask<int>("Enter [underline blue]Account ID[/]:");
        int pin = AnsiConsole.Ask<int>("Enter pin:");
        try
        {
            if (_accountService.Login(accountId, pin))
            {
                AnsiConsole.WriteLine("Login complete");
                return true;
            }

            AnsiConsole.WriteLine("Incorrect id or pin");
            return false;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }
}