namespace Application.Contracts.Admin;

public interface IAdminService
{
    bool Login(string password);
    void LogOut();
    int AddAccount(int pin);
    bool ChangeAdminPassword(string newPassword);
    bool ChangeAdminPasswordSettings(string newPassword, int maxChar, int exactChar);
}