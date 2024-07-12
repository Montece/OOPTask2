using OOPTask2.Model.Arguments;
using Xunit;

namespace OOPTask2.Tests.Arguments;

public sealed class NumberArgumentTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(5)]
    [InlineData(99999)]
    public void NumberArgument_Create(double number)
    {
        var argument = new NumberArgument(number);
        Assert.Equal(number, argument.Value);
    }
}