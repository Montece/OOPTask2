using OOPTask2.Commands.Arguments;
using Xunit;

namespace OOPTask2.Tests.Arguments;

public sealed class ParameterArgumentTests
{
    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("farffeglpdtfhgklfgkhlgjfgkjhbjkfg")]
    [InlineData("kek")]
    [InlineData("!!!!!!f")]
    public void ParameterArgument_Create(string parameterName)
    {
        var argument = new ParameterArgument(parameterName);
        Assert.Equal(argument.Value, argument.Value);
    }
}