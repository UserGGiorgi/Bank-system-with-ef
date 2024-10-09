using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.EF.Entities;
[Table("currency_code")]
public class CurrencyCode
{
    [Key]
    [Column("currency_code_id")]
    public int Id { get; set; }

    [Column("currency_code")]
    [MaxLength(5)]
    public string CurrenciesCode { get; set; }

}
