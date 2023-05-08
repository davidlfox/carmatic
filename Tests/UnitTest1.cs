using Bank;

public class UnitTest1
{
    [Fact]
    public void DepositTest()
    {
        var account = new SavingsAccount("John Doe", 100);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Deposit, account, 50);

        Assert.Equal(150, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        var account = new SavingsAccount("John Doe", 100);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Withdraw, account, 50);

        Assert.Equal(50, account.Balance);
    }

    [Fact]
    public void TransferTest()
    {
        var sourceAccount = new SavingsAccount("John Doe", 100);
        var targetAccount = new SavingsAccount("Jane Doe", 100);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Transfer, sourceAccount, 50, targetAccount);

        Assert.Equal(50, sourceAccount.Balance);
        Assert.Equal(150, targetAccount.Balance);
    }

    [Fact]
    public void IndividualCheckingAccountWithdrawLimitTest()
    {
        var account = new CheckingAccount("John Doe", 1500, CheckingAccount.CheckingType.Individual);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Withdraw, account, 1200);

        // Withdrawal should not go through due to limit
        Assert.Equal(1500, account.Balance);
    }

    [Fact]
    public void MoneyMarketCheckingAccountNoWithdrawLimitTest()
    {
        var account = new CheckingAccount("John Doe", 5000, CheckingAccount.CheckingType.MoneyMarket);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Withdraw, account, 1200);

        // Withdrawal should go through because it's a Money Market account with no limit
        Assert.Equal(5000 - 1200, account.Balance);
    }

    [Fact]
    public void WithdrawMoreThanBalanceTest()
    {
        var account = new SavingsAccount("John Doe", 100);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Withdraw, account, 200);

        // Withdrawal should not go through due to insufficient balance
        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void TransferMoreThanBalanceTest()
    {
        var sourceAccount = new SavingsAccount("John Doe", 100);
        var targetAccount = new SavingsAccount("Jane Doe", 100);
        Transaction.ExecuteTransaction(Transaction.TransactionType.Transfer, sourceAccount, 200, targetAccount);

        // Transfer should not go through due to insufficient source balance
        Assert.Equal(100, sourceAccount.Balance);
        Assert.Equal(100, targetAccount.Balance);
    }

    [Fact]
    public void BankCreationTest()
    {
        var bank = new Bank.Bank("Test Bank");

        Assert.Equal("Test Bank", bank.Name);
        Assert.Empty(bank.Accounts);
    }

    [Fact]
    public void AddAccountToBankTest()
    {
        var bank = new Bank.Bank("Test Bank");
        var account = new SavingsAccount("John Doe", 100);

        bank.Accounts.Add(account);

        Assert.Single(bank.Accounts);
        Assert.Contains(account, bank.Accounts);
    }
}