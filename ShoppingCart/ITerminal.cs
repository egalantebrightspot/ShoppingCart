namespace ShoppingCart.Core
{
    public interface ITerminal
    {
        void Scan(string item); 
        decimal Total();
    }
}