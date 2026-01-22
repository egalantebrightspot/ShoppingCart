namespace ShoppingCart.Core
{
    public static class ProductCatalog
    {
        public static IReadOnlyDictionary<string, PricingRule> 
            DefaultRules => new Dictionary<string, PricingRule>
        {
            ["A"] = new("A", 2.00m, 4, 7.00m), 
            ["B"] = new("B", 12.00m), 
            ["C"] = new("C", 1.25m, 6, 6.00m), 
            ["D"] = new("D", 0.15m)
        };
    }
}