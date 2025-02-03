using Application.Models;

namespace Application.Abstraction.Repositories;

public interface IAdminRepository
{
    AdminPassword? GetAdminPassword { get; }
    public void GetUpSql();
    public void GetDownSql();
    public bool CheckIfUp();
    public void ChangeAdminPasswordSettings(AdminPassword newPassword);
}