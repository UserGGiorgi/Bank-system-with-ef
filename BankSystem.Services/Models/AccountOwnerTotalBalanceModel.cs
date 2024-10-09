using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Services.Models;
[Table("AccountOwnerTotalBalance")]
public class AccountOwnerTotalBalanceModel
{
    [Key]
    [Column("AccountOwnerId")]
    public int AccountOwnerId { get; set; }

    [Column("FirstName")]
    public string FirstName { get; set; }

    [Column("LastName")]
    public string LastName { get; set; }

    [Column("CurrencyCode")]
    public string CurrencyCode { get; set; }

    [Column("Total")]
    public decimal Total { get; set; }
}
