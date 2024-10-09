namespace BankSystem.Services.Models;
public class AccountCashOperation
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Note { get; }

    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.Date = date;
        this.Note = note;
    }

    public override string ToString()
    {
        string operationType = this.Amount >= 0 ? "Credited to account " : "Debited from account -";
        return $"{this.Date:MM/dd/yyyy HH:mm:ss} {this.Note} : {operationType}{(int)Math.Abs(this.Amount)}.";
    }
}
