using BankSystem.EF.Entities;
using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;
public abstract class BankAccount
{
    private readonly List<AccountCashOperation> operations;

    protected BankAccount(AccountOwner owner, string currencyCode, Generators.IUniqueNumberGenerator uniqueNumberGenerator)
    {
        this.AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        this.Number = uniqueNumberGenerator?.Generate() ?? throw new ArgumentNullException(nameof(uniqueNumberGenerator));
        this.operations = [];
    }

    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> uniqueNumberGenerator)
    {
        this.AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        this.Number = uniqueNumberGenerator?.Invoke() ?? throw new ArgumentNullException(nameof(uniqueNumberGenerator));
        this.operations = [];
    }

    protected BankAccount(AccountOwner owner, string currencyCode, Generators.IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        this.Number = uniqueNumberGenerator?.Generate() ?? throw new ArgumentNullException(nameof(uniqueNumberGenerator));
        this.operations = [];
        this.Balance = initialBalance;
    }

    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> uniqueNumberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        this.Number = uniqueNumberGenerator?.Invoke() ?? throw new ArgumentNullException(nameof(uniqueNumberGenerator));
        this.operations = [];
        this.Balance = initialBalance;
    }
    public int Id { get; set; }

    public int AccountOwnerId { get; set; }

    public string Number { get; set; }

    public decimal Balance { get; protected set; }

    public int CurrencyCodeId { get; set; }

    public int BonusPoints { get; protected set; }

    protected virtual decimal Overdraft { get; set; }

    public AccountOwner AccountOwner { get; set; }

    public string CurrencyCode { get; set; }

    public List<AccountCashOperation> GetAllOperations()
    {
        return this.operations;
    }

    public void Deposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new InvalidOperationException();
        }

        this.Balance += amount;
        this.BonusPoints += this.CalculateDepositRewardPoints(amount);
        this.operations.Add(new AccountCashOperation(amount, date, note));
    }

    public void Withdraw(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new InvalidOperationException();
        }

        if (this.Balance < amount)
        {
            throw new InvalidOperationException();
        }
        this.Balance -= amount;
        this.BonusPoints += this.CalculateWithdrawRewardPoints(amount);
        this.operations.Add(new AccountCashOperation(-amount, date, note));
    }
    protected abstract int CalculateDepositRewardPoints(decimal amount);
    protected abstract int CalculateWithdrawRewardPoints(decimal amount);
}

