namespace Bank;

public class CheckingAccount : Account
{
    public enum CheckingType
    {
        Individual,
        MoneyMarket
    }

    public CheckingType Type { get; }
    public decimal WithdrawalLimit { get; }

    public CheckingAccount(string owner, decimal initialBalance, CheckingType type) : base(owner, initialBalance)
    {
        Type = type;
        WithdrawalLimit = type == CheckingType.Individual ? 1000 : decimal.MaxValue;
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount <= WithdrawalLimit && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        
        return false;
    }
}