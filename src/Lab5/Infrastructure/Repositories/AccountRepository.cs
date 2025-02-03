using Application.Abstraction.Repositories;
using Application.Models;
using Npgsql;

namespace Infrastructure.Repositories;

internal class AccountRepository : IAccountRepository
{
    private int _linterAvaider;

    public int LinterAvaider => _linterAvaider;

    public Account? FindAccountById(int id)
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "select account_id, account_pin, account_balance from accounts where account_id = @id";
        cmd.Parameters.AddWithValue("@id", id);
        con.Open();
        NpgsqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read() is false)
            return null;

        return new Account(
            id: reader.GetInt32(0),
            pin: reader.GetInt32(1),
            balance: reader.GetDecimal(2));
    }

    public IReadOnlyList<Transaction> FindTransactionsByAccount(int id)
    {
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "select * from transactions where account_id = @id;";
        cmd.Parameters.AddWithValue("@id", id);
        con.Open();
        NpgsqlDataReader reader = cmd.ExecuteReader();

        var transactions = new List<Transaction>();
        while (reader.Read())
        {
            Transaction transaction;
            if (reader["transaction_type"].ToString() == TransactionType.Deposit.ToString())
            {
                transaction = new Transaction(
                    reader.GetInt32(3),
                    reader.GetDecimal(1),
                    TransactionType.Deposit,
                    reader.GetInt32(0));
            }
            else
            {
                transaction = new Transaction(
                    reader.GetInt32(3),
                    reader.GetDecimal(1),
                    TransactionType.Withdraw,
                    reader.GetInt32(0));
            }

            transactions.Add(transaction);
        }

        return transactions;
    }

    public void SubmitAccountTransaction(Transaction transaction, decimal newBalance)
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        if (transaction.TransactionType == TransactionType.Deposit)
        {
            cmd.CommandText =
                "insert into transactions (amount, transaction_type, account_id) values (@amount, 'Deposit', @account_id);";
        }
        else
        {
            cmd.CommandText = "insert into transactions (amount, transaction_type, account_id) values (@amount, 'Withdraw', @account_id);";
        }

        cmd.Parameters.AddWithValue("@amount", transaction.Amount);
        cmd.Parameters.AddWithValue("@account_id", transaction.AccountId);
        con.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText = "UPDATE accounts SET account_balance = @newBalance where account_id = @id;";
        cmd.Parameters.AddWithValue("@newBalance", newBalance);
        cmd.Parameters.AddWithValue("@id", transaction.AccountId);
        cmd.ExecuteNonQuery();
    }

    public int AddAccount(int pin)
    {
        _linterAvaider = 0;
        using NpgsqlConnection con = GetConnection();
        using var cmd = new NpgsqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "insert into accounts (account_pin, account_balance) VALUES  (@pin, 0);";

        cmd.Parameters.AddWithValue("@pin", pin);
        con.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText = "select max(account_id) from accounts;";
        NpgsqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        return reader.GetInt32(0);
    }

    private static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(@"Host=localhost;Port=5432;Username=postgres;Password=123;Database=postgres;");
    }
}
