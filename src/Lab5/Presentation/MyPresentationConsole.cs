using Application.Contracts.Accounts;
using Application.Contracts.Admin;
using Presentation.Commands;
using Presentation.CommandsSupport;
using Spectre.Console;

namespace Presentation;

public class MyPresentationConsole : IPresentationConsole
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;

    public MyPresentationConsole(IAccountService accountService, IAdminService adminService)
    {
        _accountService = accountService;
        _adminService = adminService;
    }

    public void Run()
    {
        CommandMapper commandMapper = ConfigureMapper(_accountService, _adminService);
        string selection, selection2;
        bool loggedIn = false;
        bool running = true;
        while (running)
        {
            AnsiConsole.Clear();
            selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices("Login as user", "Login as admin", "Exit"));
            switch (selection)
            {
                case "Login as user":
                    if (commandMapper.ExecuteCommand(selection))
                    {
                        loggedIn = true;
                    }

                    while (loggedIn)
                    {
                        selection2 = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .AddChoices("Deposit money", "Withdraw money", "Balance", "Transaction history", "Exit"));
                        switch (selection2)
                        {
                            case "Exit":
                                commandMapper.ExecuteCommand("Logout user");
                                loggedIn = false;
                                break;
                            default:
                                commandMapper.ExecuteCommand(selection2);
                                break;
                        }
                    }

                    break;
                case "Login as admin":
                    if (commandMapper.ExecuteCommand(selection))
                    {
                        loggedIn = true;
                    }

                    while (loggedIn)
                    {
                        selection2 = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .AddChoices("Add account", "Change password", "Change admin password settings", "Exit"));
                        switch (selection2)
                        {
                            case "Exit":
                                commandMapper.ExecuteCommand("Logout admin");
                                loggedIn = false;
                                break;
                            default:
                                commandMapper.ExecuteCommand(selection2);
                                break;
                        }
                    }

                    break;
                case "Exit":
                    running = false;
                    break;
            }

            AnsiConsole.Write("\nPress any key to continue");
            Console.ReadKey();
        }
    }

    private static CommandMapper ConfigureMapper(IAccountService accountService, IAdminService adminService)
    {
        var commandMapper = new CommandMapper();
        commandMapper.AddCommand("Login as user", new LoginAccountCommand(accountService));
        commandMapper.AddCommand("Login as admin", new LoginAdminCommand(adminService));
        commandMapper.AddCommand("Deposit money", new DepositCommand(accountService));
        commandMapper.AddCommand("Withdraw money", new WithdrawCommand(accountService));
        commandMapper.AddCommand("Balance", new GetBalanceCommand(accountService));
        commandMapper.AddCommand("Transaction history", new GetTransactionHistoryCommand(accountService));
        commandMapper.AddCommand("Logout user", new LogoutAccountCommand(accountService));
        commandMapper.AddCommand("Logout admin", new LogoutAdminCommand(adminService));
        commandMapper.AddCommand("Add account", new AddAccountCommand(adminService));
        commandMapper.AddCommand("Change password", new ChangeAdminPasswordCommand(adminService));
        commandMapper.AddCommand("Change admin password settings", new ChangeAdminPasswordSettingsCommand(adminService));
        return commandMapper;
    }
}