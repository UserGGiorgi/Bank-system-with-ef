using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.EF.Entities
{
    [Table("bank_account")]
    public class BankAccount
    {
        [Key]
        [Column("bank_account_id")]
        public int Id { get; set; }

        [ForeignKey("AccountOwner")]
        [Column("account_owner_id")]
        public int AccountOwnerId { get; set; }

        [Column("account_number")]
        [MaxLength(20)]
        public string Number { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [ForeignKey("CurrencyCode")]
        [Column("currency_code_id")]
        public int CurrencyCodeId { get; set; }

        [Column("bonus_points")]
        public int BonusPoints { get; set; }

        [Column("overdraft")]
        public decimal Overdraft { get; set; }
        public virtual AccountOwner AccountOwner { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
    }
}

