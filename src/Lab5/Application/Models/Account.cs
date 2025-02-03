namespace Application.Models;

public class Account
{
    public Account(int id, int pin, decimal balance)
    {
        Id = id;
        Pin = pin;
        Balance = balance;
    }

    public int Id { get; }

    public int Pin { get; internal set; }

    public decimal Balance { get; set; }
}