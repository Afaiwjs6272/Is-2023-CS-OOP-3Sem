namespace Application.Models;

public class Transaction
{
    public Transaction(int accountId, decimal amount, TransactionType transactionType,  int id = 0)
    {
        AccountId = accountId;
        Amount = amount;
        TransactionType = transactionType;
        Id = id;
    }

    public int Id { get; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public TransactionType TransactionType { get; }
}