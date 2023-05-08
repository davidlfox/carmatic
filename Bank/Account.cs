namespace Bank;

public abstract class Account
{
    public string Owner { get; }
    public decimal Balance { get; protected set; }

    public Account(string owner, decimal initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public abstract void Deposit(decimal amount);
    public abstract bool Withdraw(decimal amount);
}