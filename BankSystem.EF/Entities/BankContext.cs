using Microsoft.EntityFrameworkCore;

namespace BankSystem.EF.Entities;
public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }
    public DbSet<AccountOwner> AccountOwners { get; set; }
    public DbSet<CurrencyCode> CurrencyCodes { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<AccountCashOperation> AccountCashOperations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<AccountOwner>(entity =>
        {
            _ = entity.ToTable("account_owner");
            _ = entity.HasKey(e => e.Id);
            _ = entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            _ = entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            _ = entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        });

        _ = modelBuilder.Entity<CurrencyCode>(entity =>
        {
            _ = entity.ToTable("currency_code");
            _ = entity.HasKey(e => e.Id);
            _ = entity.Property(e => e.CurrenciesCode).IsRequired().HasMaxLength(5);
        });

        _ = modelBuilder.Entity<BankAccount>(entity =>
        {
            _ = entity.ToTable("bank_account");
            _ = entity.HasKey(e => e.Id);
            _ = entity.Property(e => e.Number).IsRequired().HasMaxLength(20);
            _ = entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
            _ = entity.Property(e => e.BonusPoints).HasColumnType("int");
            _ = entity.Property(e => e.Overdraft).HasColumnType("decimal(18,2)");

            _ = entity.HasOne(e => e.AccountOwner)
                .WithMany()
                .HasForeignKey(e => e.AccountOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            _ = entity.HasOne(e => e.CurrencyCode)
                .WithMany()
                .HasForeignKey(e => e.CurrencyCodeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        _ = modelBuilder.Entity<AccountCashOperation>(entity =>
        {
            _ = entity.ToTable("account_cash_operation");
            _ = entity.HasKey(e => e.Id);
            _ = entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            _ = entity.Property(e => e.OperationDateTime).HasColumnType("datetime");
            _ = entity.Property(e => e.Note).HasMaxLength(255);

            _ = entity.HasOne(e => e.BankAccount)
                .WithMany()
                .HasForeignKey(e => e.BankAccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
