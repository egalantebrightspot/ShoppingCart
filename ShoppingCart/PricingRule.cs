namespace ShoppingCart.Core
{
    public sealed class PricingRule(string productCode, decimal unitPrice, int? volumeQuantity = null,
        decimal? volumePrice = null)
    {
        public string ProductCode { get; } = productCode;
        public decimal UnitPrice { get; } = unitPrice;
        public int? VolumeQuantity { get; } = volumeQuantity;
        public decimal? VolumePrice { get; } = volumePrice;
    }
}