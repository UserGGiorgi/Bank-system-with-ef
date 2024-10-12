using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;
public class OwnerService : IDisposable
{
    private readonly BankContext _context;

    public OwnerService(BankContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        return this._context.AccountOwners
            .Select(a => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                CurrencyCode = a.BankAccounts.FirstOrDefault().CurrencyCode.CurrenciesCode,
                Total = (decimal)a.BankAccounts.Sum(b => (double)b.Balance)
            })
            .OrderByDescending(a => (double)a.Total)
            .ToList()
            .AsReadOnly();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        this._context?.Dispose();
    }
}
