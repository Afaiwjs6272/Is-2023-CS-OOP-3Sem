using Application.Contracts.Accounts;
using Application.Models;
using Spectre.Console;

namespace Presentation.Commands;

public class GetTransactionHistoryCommand : ICommand
{
    private IAccountService _accountService;

    public GetTransactionHistoryCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        var grid = new Grid();
        grid.AddColumn().AddColumn().AddColumn();
        grid.AddRow("Transaction Id", "Transaction Type", "Amount");
        IReadOnlyList<Transaction> history = _accountService.GetTransactionHistory();
        for (int i = 0; i < history.Count; i++)
        {
            grid.AddRow(new string[]
            {
                $"{history[i].Id}", $"{history[i].TransactionType.ToString()}",
                $"{history[i].Amount}",
            });
        }

        AnsiConsole.Write(grid);
        return true;
    }
}