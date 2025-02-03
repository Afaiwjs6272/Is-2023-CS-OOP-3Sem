using Application.Models;

namespace Application.Contracts.Accounts;

public interface IAccountService
{
    bool Login(int accountId, int pin);
    void DepositMoney(decimal amount);
    bool TryWithdrawMoney(decimal amount);
    decimal GetBalance();
    IReadOnlyList<Transaction> GetTransactionHistory();
    void LogOut();
}