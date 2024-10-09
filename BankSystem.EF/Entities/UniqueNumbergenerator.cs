namespace BankSystem.EF.Entities;
public class UniqueNumberGenerator : IUniqueNumberGenerator
{
    public string GenerateUniqueNumber()
    {
        return Guid.NewGuid().ToString();
    }
}
