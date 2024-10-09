using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
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
        ArgumentException.ThrowIfNullOrEmpty(email);
        ValidateEmail(email);
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
    }

    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    private List<BankAccount> AccountsList { get; set; }
    public static void ValidateEmail(string email)
    {
        if (email == null || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        }

        if (!EmailRegex.IsMatch(email))
        {
            throw new ArgumentException("Invalid email format.", nameof(email));
        }
    }
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
        ArgumentNullException.ThrowIfNull(this.AccountsList);
        return this.AccountsList.AsReadOnly();
    }

}
