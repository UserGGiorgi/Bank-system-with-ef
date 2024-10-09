using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    public DateTime startingPoint { get; }
    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }
    public string Generate()
    {
        long elapsedTicks = (DateTime.Now - this.startingPoint).Ticks;

        string ticks = elapsedTicks.ToString(CultureInfo.InvariantCulture);
        return ticks.GenerateHash();
    }
}
