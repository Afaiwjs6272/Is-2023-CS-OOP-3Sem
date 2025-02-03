using Application.Abstraction.Repositories;
using Application.Contracts.Admin;
using Application.Models;
using Application.Tools;

namespace Application.Application.Admin;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAdminRepository _adminRepository;
    private bool _loggedIn;
    private AdminPassword _adminPassword;
    public AdminService(IAccountRepository accountRepository, IAdminRepository adminRepository)
    {
        _accountRepository = accountRepository;
        _adminRepository = adminRepository;
        _adminRepository.GetUpSql();
        _adminPassword = _adminRepository.GetAdminPassword ?? throw new CustomException("There is no recorded admin password.");
        _loggedIn = false;
    }

    public bool Login(string password)
    {
        if (_loggedIn)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        if (password != _adminPassword.Password)
        {
            return false;
        }

        _loggedIn = true;
        return true;
    }

    public void LogOut()
    {
        _loggedIn = false;
    }

    public int AddAccount(int pin)
    {
        if (!_loggedIn)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        return _accountRepository.AddAccount(pin);
    }

    public bool ChangeAdminPassword(string newPassword)
    {
        if (_adminPassword.ChangePassword(newPassword))
        {
            _adminRepository.ChangeAdminPasswordSettings(_adminPassword);
            return true;
        }

        return false;
    }

    public bool ChangeAdminPasswordSettings(string newPassword, int maxChar, int exactChar)
    {
        try
        {
            _adminPassword = new AdminPassword(newPassword, maxChar, exactChar);
        }
        catch (CustomException)
        {
            return false;
        }

        _adminRepository.ChangeAdminPasswordSettings(_adminPassword);
        return true;
    }
}