
using BankSystem.Services.Models.Accounts;
using NUnit.Framework;

namespace BankSystem.Tests.Services;

[TestFixture]
public sealed class StandardAccountTests
{
    private BankSystem.Services.Models.AccountOwner owner = null!;
    private BankSystem.Services.Generators.IUniqueNumberGenerator dummyInterfaceGenerator = null!;
    private Func<string> dummyFunctionGenerator = null!;
    private string currencyCode = null!;
    private decimal amount;

    [SetUp]
    public void SetUp()
    {
        this.owner = new BankSystem.Services.Models.AccountOwner("Zack", "Mills", "Zack.Mills@mail.com");
        this.dummyInterfaceGenerator = new DummyUniqueNumberGenerator();
        this.dummyFunctionGenerator = () => "1234567890";
        this.currencyCode = "USD";
    }

    [Test]
    public void Constructor_WithThreeParametersAndInterfaceGenerator()
    {
        var account = new StandardAccount(this.owner, this.currencyCode, this.dummyInterfaceGenerator);
        Assert.That(this.owner, Is.EqualTo(account.AccountOwner));
        Assert.That(account.CurrencyCode == this.currencyCode);
        Assert.That(account.Balance == 0);
        Assert.That(account.BonusPoints == 0);
        Assert.That(account.GetAllOperations().Count == 0);
    }

    [Test]
    public void Constructor_WithFourParametersAndInterfaceGenerator()
    {
        this.amount = 123m;
        var account = new StandardAccount(this.owner, this.currencyCode, this.dummyInterfaceGenerator, this.amount);
        Assert.That(this.owner, Is.EqualTo(account.AccountOwner));
        Assert.That(account.CurrencyCode == this.currencyCode);
        Assert.That(account.Balance == this.amount);
        Assert.That(account.BonusPoints == 1);
        Assert.That(account.GetAllOperations().Count == 1);
    }

    [Test]
    public void Constructor_WithThreeParametersAndDelegateGenerator()
    {
        var account = new StandardAccount(this.owner, this.currencyCode, this.dummyFunctionGenerator);
        Assert.That(this.owner, Is.EqualTo(account.AccountOwner));
        Assert.That(account.CurrencyCode == this.currencyCode);
        Assert.That(account.Balance == 0);
        Assert.That(account.BonusPoints == 0);
        Assert.That(account.GetAllOperations().Count == 0);
    }

    [Test]
    public void Constructor_WithFourParametersAndDelegateGenerator()
    {
        this.amount = 123m;
        var account = new StandardAccount(this.owner, this.currencyCode, this.dummyFunctionGenerator, this.amount);
        Assert.That(this.owner, Is.EqualTo(account.AccountOwner));
        Assert.That(account.CurrencyCode == this.currencyCode);
        Assert.That(account.Balance == this.amount);
        Assert.That(account.BonusPoints == 1);
        Assert.That(account.GetAllOperations().Count == 1);
    }

    [Test]
    public void Deposit_ThreeCallChain_VerifyBalanceAndBonusPoints()
    {
        var account = new StandardAccount(this.owner, "EUR", () => "40895268");
        account.Deposit(632.83m, new DateTime(2024, 2, 4, 20, 29, 44), "implement Specialist turn - key");
        account.Deposit(975.09m, new DateTime(2024, 1, 1, 12, 29, 30), "Light intermediate Intelligent Fresh Table");
        account.Deposit(923.84m, new DateTime(2024, 4, 3, 20, 29, 44), "Wells Colorado Montana");
        Assert.That(account.Balance == 2531.76m);
        Assert.That(account.BonusPoints == 47);
    }

    [Test]
    public void Deposit_TwoCallChain_VerifyBalanceAndBonusPoints()
    {
        var account = new StandardAccount(this.owner, "EUR", () => "20895248", 632.83m);
        account.Deposit(975.09m, new DateTime(2024, 1, 1, 12, 29, 30), "Light intermediate Intelligent Fresh Table");
        account.Deposit(923.84m, new DateTime(2024, 2, 4, 20, 29, 44), "Wells Colorado Montana");
        Assert.That(account.Balance == 2531.76m);
        Assert.That(account.BonusPoints == 47);
    }

    [Test]
    public void DepositAndWithdraw_CallChain_VerifyBalanceAndBonusPoints()
    {
        var account = new StandardAccount(this.owner, "USD", () => "40895268");
        account.Deposit(599.07m, new DateTime(2024, 1, 1, 12, 29, 30), "Nigeria Sports & Toys");
        account.Deposit(768.31m, new DateTime(2024, 4, 3, 14, 10, 4), "evolve : Credited to account");
        account.Withdraw(38.31m, new DateTime(2024, 3, 4, 13, 29, 44), "District Cambridge Concrete");
        account.Withdraw(310.20m, new DateTime(2024, 1, 3, 9, 5, 5), "Developer Croatia Fantastic Granite Keyboard");
        account.Deposit(959.95m, new DateTime(2024, 1, 4, 20, 29, 44), "Kentucky primary");
        account.Deposit(890.58m, new DateTime(2024, 3, 2, 12, 3, 3), "lavender");
        account.Withdraw(789.32m, new DateTime(2024, 4, 23, 12, 13, 5), "human-resource");
        Assert.That(account.Balance == 2080.08m);
        Assert.That(account.BonusPoints == 108);
    }

    private sealed class DummyUniqueNumberGenerator : BankSystem.Services.Generators.IUniqueNumberGenerator
    {
        public string Generate() => "1234567890";
    }
}
