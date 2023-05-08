namespace Bank;

public class SavingsAccount : Account
{
    public SavingsAccount(string owner, decimal initialBalance) : base(owner, initialBalance)
    {
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}