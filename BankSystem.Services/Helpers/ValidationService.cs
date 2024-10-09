using System.Globalization;
using System.Text.RegularExpressions;

namespace BankSystem.Services.Helpers;

public static class ValidatorService
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static bool IsCurrencyValid(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            return false;
        }

        var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        foreach (var culture in cultures)
        {
            var region = new RegionInfo(culture.Name);
            if (region.ISOCurrencySymbol.Equals(currencyCode, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsEmailValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return EmailRegex.IsMatch(email);
    }
}
