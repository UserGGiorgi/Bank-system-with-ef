using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.EF.Entities;

[Table("account_owner")]
public class AccountOwner
{
    [Key]
    [Column("account_owner_id")]
    public int Id { get; set; }

    [Column("first_name")]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Column("email")]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
}
