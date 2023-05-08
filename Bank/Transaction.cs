namespace Bank;

public class Transaction
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Transfer
    }

    public static void ExecuteTransaction(TransactionType type, Account source, decimal amount, Account target = null)
    {
        switch (type)
        {
            case TransactionType.Deposit:
                source.Deposit(amount);
                break;
            case TransactionType.Withdraw:
                source.Withdraw(amount);
                break;
            case TransactionType.Transfer:
                if (target != null)
                {
                    if (source.Withdraw(amount))
                    {
                        target.Deposit(amount);
                    }
                }
                break;
        }
    }
}