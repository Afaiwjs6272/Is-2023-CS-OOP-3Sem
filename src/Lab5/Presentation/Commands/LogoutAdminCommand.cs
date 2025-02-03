using Application.Contracts.Admin;

namespace Presentation.Commands;

public class LogoutAdminCommand : ICommand
{
    private IAdminService _adminService;

    public LogoutAdminCommand(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool Execute()
    {
        _adminService.LogOut();
        return true;
    }
}