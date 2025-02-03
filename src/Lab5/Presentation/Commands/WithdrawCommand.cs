using Application.Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Commands;

public class WithdrawCommand : ICommand
{
    private IAccountService _accountService;

    public WithdrawCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        int amount = AnsiConsole.Ask<int>("Enter withdraw amount:");
        try
        {
            AnsiConsole.WriteLine(_accountService.TryWithdrawMoney(amount)
                ? "Operation complete"
                : "Not enough money");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}