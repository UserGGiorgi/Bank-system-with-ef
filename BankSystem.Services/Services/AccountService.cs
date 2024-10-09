using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;
public class AccountService : IDisposable
{
    private readonly BankContext _context;

    public AccountService(BankContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        return this._context.BankAccounts
            .Select(b => new BankAccountFullInfoModel
            {
                BankAccountId = b.Id,
                FirstName = b.AccountOwner.FirstName,
                LastName = b.AccountOwner.LastName,
                AccountNumber = b.Number,
                Balance = b.Balance,
                CurrencyCode = b.CurrencyCode.CurrenciesCode,
                BonusPoints = b.BonusPoints
            })
            .ToList()
            .AsReadOnly();
    }

    public void Dispose()
    {
        this._context?.Dispose();
    }
}
