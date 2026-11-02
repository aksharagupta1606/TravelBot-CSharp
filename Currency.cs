namespace TravelBot;

public sealed class Currency
{
    public string Code { get; init; } = "";
    public double USDPerUnit { get; init; }
    public double UnitsPerUSD => 1.0 / USDPerUnit;

    public static Dictionary<string, Currency> Load(string path)
    {
        var result = new Dictionary<string, Currency>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in File.ReadAllLines(path))
        {
            var clean = line.Trim();
            if (clean.Length == 0 || clean.StartsWith("#")) continue;
            var parts = clean.Split(',', StringSplitOptions.TrimEntries);
            if (parts.Length == 2 &&
                double.TryParse(parts[1], System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out var rate) &&
                rate > 0)
            {
                result[parts[0].ToUpperInvariant()] = new Currency
                {
                    Code = parts[0].ToUpperInvariant(),
                    USDPerUnit = rate
                };
            }
        }
        return result;
    }
}
