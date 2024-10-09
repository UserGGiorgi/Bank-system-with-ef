using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace BankSystem.Services.Generators;

public class SimpleGenerator : IUniqueNumberGenerator
{
    private int lastNumber = 1234567890;

    private SimpleGenerator() { }

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    public static SimpleGenerator Instance { get; private set; }

    public string Generate()
    {
        this.lastNumber++;
        byte[] inputBytes = Encoding.UTF8.GetBytes(this.lastNumber.ToString(CultureInfo.InvariantCulture));
        byte[] hashBytes = MD5.HashData(inputBytes);
        return Convert.ToBase64String(hashBytes);
    }
}




