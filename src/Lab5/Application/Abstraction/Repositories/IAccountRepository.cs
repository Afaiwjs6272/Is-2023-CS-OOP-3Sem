using Application.Models;

namespace Application.Abstraction.Repositories;

public interface IAccountRepository
{
    Account? FindAccountById(int id);
    IReadOnlyList<Transaction> FindTransactionsByAccount(int id);
    void SubmitAccountTransaction(Transaction transaction, decimal newBalance);
    int AddAccount(int pin);
}