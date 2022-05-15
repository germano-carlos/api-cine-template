using Xunit;

namespace EasyCine.Tests;

public class UserTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(1)] // Gera erro !
    [InlineData(3)]
    public void IsNotEven(int value)
    {
        var result = value % 2 == 0;
        Assert.False(result, $"{value} should not be prime");
    }
}