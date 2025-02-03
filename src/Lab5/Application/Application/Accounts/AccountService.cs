using Application.Abstraction.Repositories;
using Application.Contracts.Accounts;
using Application.Models;
using Application.Tools;

namespace Application.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentAccountService _currentAccountService;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        _currentAccountService = new CurrentAccountService();
    }

    public bool Login(int accountId, int pin)
    {
        if (_currentAccountService.Account is not null)
        {
            throw new CustomException("Account already logged in.");
        }

        Account? account = _accountRepository.FindAccountById(accountId);
        if (account is null)
        {
            return false;
        }

        if (account.Pin != pin)
        {
            return false;
        }

        _currentAccountService.Account = account;
        return true;
    }

    public void DepositMoney(decimal amount)
    {
        if (amount < 0)
        {
            throw new CustomException("Incorrect deposit amount.");
        }

        if (_currentAccountService.Account == null)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        _currentAccountService.Account.Balance += amount;
        var transaction = new Transaction(_currentAccountService.Account.Id, amount, TransactionType.Deposit);
        _accountRepository.SubmitAccountTransaction(transaction, _currentAccountService.Account.Balance);
    }

    public bool TryWithdrawMoney(decimal amount)
    {
        if (amount < 0)
        {
            throw new CustomException("Incorrect withdraw amount.");
        }

        if (_currentAccountService.Account == null)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        if (_currentAccountService.Account.Balance < amount)
        {
            return false;
        }

        _currentAccountService.Account.Balance -= amount;
        var transaction = new Transaction(_currentAccountService.Account.Id, amount, TransactionType.Withdraw);
        _accountRepository.SubmitAccountTransaction(transaction, _currentAccountService.Account.Balance);
        return true;
    }

    public decimal GetBalance()
    {
        if (_currentAccountService.Account == null)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        return _currentAccountService.Account.Balance;
    }

    public IReadOnlyList<Transaction> GetTransactionHistory()
    {
        if (_currentAccountService.Account == null)
        {
            throw new CustomException("You haven't logged in. how you ever accessed that method?");
        }

        return _accountRepository.FindTransactionsByAccount(_currentAccountService.Account.Id);
    }

    public void LogOut()
    {
        _currentAccountService.Account = null;
    }
}