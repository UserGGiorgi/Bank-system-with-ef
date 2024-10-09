using System.Collections.ObjectModel;
using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;
public class AccountOwner
{
    public AccountOwner(string firstName, string lastName, string email)
    {
        if (firstName == null || string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException("", nameof(firstName));
        }
        if (lastName == null || string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException("", nameof(lastName));
        }
        if (email == null || string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("", nameof(email));
        }
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    private List<BankAccount> AccountsList { get; set; }

    public override string ToString()
    {
        string answer = $"{this.FirstName} {this.LastName}, {this.Email}.";
        return answer;
    }

    public void Add(BankAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);
        this.AccountsList.Add(account);
    }

    public ReadOnlyCollection<BankAccount> Accounts()
    {
        return this.AccountsList.AsReadOnly();
    }
}
