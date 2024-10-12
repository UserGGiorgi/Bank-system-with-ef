using System.Text.RegularExpressions;
using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;
public class AccountOwner
{
    public AccountOwner(string firstName, string lastName, string email)
    {
        VerifyString(firstName, nameof(firstName));
        VerifyString(lastName, nameof(lastName));
        VerifyString(email, nameof(email));
        ArgumentException.ThrowIfNullOrEmpty(email);
        ValidateEmail(email);
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.AccountsList = [];
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
        ArgumentNullException.ThrowIfNull(this.AccountsList);
        this.AccountsList.Add(account);
    }

    public ICollection<BankAccount> Accounts()
    {
        return this.AccountsList;
    }

    private static void VerifyString(string value, string name)
    {
        if (value == null || string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("IsNull", name);
        }
    }

}
