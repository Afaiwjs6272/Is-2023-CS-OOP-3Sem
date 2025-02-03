using Application.Contracts.Accounts;

namespace Presentation.Commands;

public class LogoutAccountCommand : ICommand
{
    private IAccountService _accountService;

    public LogoutAccountCommand(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public bool Execute()
    {
        _accountService.LogOut();
        return true;
    }
}