using Application.Abstraction.Repositories;
using Application.Models;

namespace Infrastructure.Repositories;

public class MockAccountRepository : IAccountRepository
{
    private int _linterAvaider;
    public int LinterAvaider => _linterAvaider;
    public Account? FindAccountById(int id)
    {
        _linterAvaider = 0;
        return new Account(id, 1234, 0);
    }

    public IReadOnlyList<Transaction> FindTransactionsByAccount(int id)
    {
        throw new NotImplementedException();
    }

    public void SubmitAccountTransaction(Transaction transaction, decimal newBalance)
    {
        _linterAvaider = 0;
    }

    public int AddAccount(int pin)
    {
        _linterAvaider = 0;
        return 1;
    }
}