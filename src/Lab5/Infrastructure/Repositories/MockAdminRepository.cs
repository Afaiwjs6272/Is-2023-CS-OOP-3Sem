using Application.Abstraction.Repositories;
using Application.Models;

namespace Infrastructure.Repositories;

public class MockAdminRepository : IAdminRepository
{
    private int _linterAvaider;
    public int LinterAvaider => _linterAvaider;

    public AdminPassword? GetAdminPassword
    {
        get
        {
            _linterAvaider = 0;
            return new AdminPassword("pass", 0, 0);
        }
    }

    public void GetUpSql()
    {
        _linterAvaider = 0;
        return;
    }

    public void GetDownSql()
    {
        throw new NotImplementedException();
    }

    public bool CheckIfUp()
    {
        throw new NotImplementedException();
    }

    public void ChangeAdminPasswordSettings(AdminPassword newPassword)
    {
        throw new NotImplementedException();
    }
}