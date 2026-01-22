using ShoppingCart.Core;
namespace ShoppingCart.Tests;

public class TerminalTests
{
    private static Terminal CreateTerminal() => new(ProductCatalog.DefaultRules.Values);

    [Fact]
    public void TestCase1()
    {
        var terminal = CreateTerminal();
        "ABCDABAA".ToList().ForEach(c => terminal.Scan(c.ToString()));
        Assert.Equal(32.40m, terminal.Total());
    }

    [Fact]
    public void TestCase2()
    {
        var terminal = CreateTerminal();
        "CCCCCCC".ToList().ForEach(c => terminal.Scan(c.ToString()));
        Assert.Equal(7.25m, terminal.Total());
    }

    [Fact]
    public void TestCase3()
    {
        var terminal = CreateTerminal();
        "ABCD".ToList().ForEach(c => terminal.Scan(c.ToString()));
        Assert.Equal(15.40m, terminal.Total());
    }
}