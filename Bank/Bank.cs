namespace Bank;

public class Bank
{
    public string Name { get; }
    public List<Account> Accounts { get; }

    public Bank(string name)
    {
        Name = name;
        Accounts = new List<Account>();
    }
}