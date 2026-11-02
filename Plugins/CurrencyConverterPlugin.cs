using System.ComponentModel;
using System.Globalization;
using Microsoft.SemanticKernel;

namespace TravelBot.Plugins;

public sealed class CurrencyConverterPlugin
{
    private readonly Dictionary<string, Currency> currencies;

    public CurrencyConverterPlugin(Dictionary<string, Currency> currencies)
        => this.currencies = currencies;

    [KernelFunction("ConvertAmount")]
    [Description("Converts an amount from one currency to another using the rates in currencies.txt.")]
    public string ConvertAmount(
        [Description("Amount to convert, for example 52000")] string amount,
        [Description("Three-letter source currency code, for example VND")] string baseCurrencyCode,
        [Description("Three-letter target currency code, for example USD")] string targetCurrencyCode)
    {
        if (!double.TryParse(amount, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            return "Please provide a valid numeric amount.";

        if (!currencies.TryGetValue(baseCurrencyCode.ToUpperInvariant(), out var baseCurrency))
            return $"{baseCurrencyCode} was not found.";

        if (!currencies.TryGetValue(targetCurrencyCode.ToUpperInvariant(), out var targetCurrency))
            return $"{targetCurrencyCode} was not found.";

        var amountInUsd = value * baseCurrency.USDPerUnit;
        var converted = amountInUsd * targetCurrency.UnitsPerUSD;
        return $"{value.ToString(CultureInfo.InvariantCulture)} {baseCurrency.Code} is approximately {converted:F2} {targetCurrency.Code}.";
    }
}
