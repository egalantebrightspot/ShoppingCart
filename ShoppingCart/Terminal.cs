namespace ShoppingCart.Core;

public sealed class Terminal : ITerminal
{
    private readonly Dictionary<string, PricingRule> _rules;
    private readonly Dictionary<string, int> _cart = new();

    public Terminal(IEnumerable<PricingRule> pricingRules)
    {
        _rules = pricingRules.ToDictionary(r => r.ProductCode);
    }

    public void Scan(string item)
    {
        if (!_rules.ContainsKey(item))
            throw new ArgumentException($"Unknown product code: {item}");

        _cart.TryAdd(item, 0);
        _cart[item]++;
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (var (product, qty) in _cart)
        {
            var rule = _rules[product];

            if (rule is { VolumeQuantity: not null, VolumePrice: not null })
            {
                var volumeQty = rule.VolumeQuantity.Value;
                var volumePrice = rule.VolumePrice.Value;

                var bundles = qty / volumeQty;
                var remainder = qty % volumeQty;

                total += bundles * volumePrice;
                total += remainder * rule.UnitPrice;
            }
            else
            {
                total += qty * rule.UnitPrice;
            }
        }

        return total;
    }
}