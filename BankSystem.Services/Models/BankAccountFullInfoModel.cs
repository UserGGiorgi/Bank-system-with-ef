using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Services.Models;
[Table("BankAccountFullInfo")]
public class BankAccountFullInfoModel
{
    [Key]
    [Column("BankAccountId")]
    public int BankAccountId { get; set; }

    [Column("FirstName")]
    public string FirstName { get; set; }

    [Column("LastName")]
    public string LastName { get; set; }

    [Column("AccountNumber")]
    public string AccountNumber { get; set; }

    [Column("Balance")]
    public decimal Balance { get; set; }

    [Column("CurrencyCode")]
    public string CurrencyCode { get; set; }

    [Column("BonusPoints")]
    public int BonusPoints { get; set; }
}
