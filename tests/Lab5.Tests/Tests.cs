using Application.Application.Accounts;
using Application.Application.Admin;
using Infrastructure.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void WithdrawAttempt()
    {
        var mockAdminRepository = new MockAdminRepository();
        var mockAccountRepository = new MockAccountRepository();
        var accountService = new AccountService(mockAccountRepository);
        var adminService = new AdminService(mockAccountRepository, mockAdminRepository);
        adminService.Login("pass");
        adminService.AddAccount(1234);
        adminService.LogOut();
        accountService.Login(1, 1234);
        accountService.DepositMoney(1000);
        accountService.TryWithdrawMoney(800);
        accountService.GetBalance();
        Assert.Equal(200, accountService.GetBalance());
        accountService.DepositMoney(5000);
        accountService.TryWithdrawMoney(4800);
        Assert.Equal(400, accountService.GetBalance());
        accountService.TryWithdrawMoney(400);
        Assert.Equal(0, accountService.GetBalance());
    }

    [Fact]
    public void BalanceCheck()
    {
        var mockAccountRepository = new MockAccountRepository();
        var accountService = new AccountService(mockAccountRepository);
        accountService.Login(1, 1234);
        decimal balancePrev = accountService.GetBalance();
        accountService.DepositMoney(1000);
        Assert.Equal(balancePrev + 1000, accountService.GetBalance());
        accountService.TryWithdrawMoney(1000);
        Assert.Equal(0, accountService.GetBalance());
        accountService.LogOut();
        accountService.Login(1, 1234);
        accountService.DepositMoney(100);
        Assert.Equal(100, accountService.GetBalance());
    }
}