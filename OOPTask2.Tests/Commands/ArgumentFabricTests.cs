using OOPTask2.Commands.Arguments;
using Xunit;

namespace OOPTask2.Tests.Commands;

public sealed class ArgumentFabricTests
{
    [Theory]
    [InlineData("x")]
    [InlineData("x2")]
    [InlineData("zwe")]
    public void ArgumentFabric_IsParameter(string argument)
    {
        Assert.True(ArgumentFabric.IsParameter(argument), "Wrong input format for parameter argument!");
    }

    [Theory]
    [InlineData("x q")]
    [InlineData("99eq")]
    [InlineData("e!")]
    public void ArgumentFabric_IsNotParameter(string argument)
    {
        Assert.False(ArgumentFabric.IsParameter(argument), "Not wrong input format for parameter argument!");
    }

    [Theory]
    [InlineData("123")]
    [InlineData("QeeweEde")]
    [InlineData("0QeeweEd1e5")]
    public void ArgumentFabric_IsText(string argument)
    {
        Assert.True(ArgumentFabric.IsText(argument), "Wrong input format for text argument!");
    }

    [Theory]
    [InlineData("*-*5")]
    [InlineData("//eq")]
    public void ArgumentFabric_IsNotText(string argument)
    {
        Assert.False(ArgumentFabric.IsText(argument), "Nor wrong input format for parameter argument!");
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-5")]
    [InlineData("785")]
    [InlineData("414,785")]
    [InlineData("-999,99")]
    [InlineData("414.5485")]
    [InlineData("-999.99")]
    public void ArgumentFabric_IsDouble(string argument)
    {
        Assert.True(ArgumentFabric.IsDouble(argument), "Wrong input format for double argument!");
    }

    [Theory]
    [InlineData("585 eqweq")]
    [InlineData("gdgd")]
    public void ArgumentFabric_IsNotDouble(string argument)
    {
        Assert.False(ArgumentFabric.IsDouble(argument), "Not wrong input format for parameter argument!");
    }
}
