using Application.Contracts.Accounts;
using Spectre.Console;

namespace Presentation.Commands;

public class GetBalanceCommand : ICommand
{
    private IAccountService _accountService;

    public GetBalanceCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        AnsiConsole.MarkupLine($"Your balance: {_accountService.GetBalance()}");
        return true;
    }
}