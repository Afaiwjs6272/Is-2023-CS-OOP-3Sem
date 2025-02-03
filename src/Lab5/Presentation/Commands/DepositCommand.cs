using Application.Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Commands;

public class DepositCommand : ICommand
{
    private IAccountService _accountService;

    public DepositCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        int amount = AnsiConsole.Ask<int>("Enter deposit amount:");
        try
        {
            _accountService.DepositMoney(amount);
            AnsiConsole.WriteLine("Operation complete");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}