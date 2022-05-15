using Xunit;

namespace EasyCine.Tests;

public class UnitTest1
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
    
    [Theory]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(2)]
    public void IsEven(int value)
    {
        var result = value % 2 == 0;
        Assert.True(result, $"{value} should not be prime");
    }
}