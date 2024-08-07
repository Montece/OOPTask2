using Moq;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class MultiplyOperatorTests
{
    [Fact]
    public void MultiplyOperator_IsMatch()
    {
        var command = new Command("*");
        var multiplyOperator = new MultiplyOperator();
        var isMatch = multiplyOperator.IsValidCommand(command);

        Assert.True(isMatch, "Wrong command for operator!");
    }

    [Theory]
    [InlineData("5 * 4")]
    [InlineData("* 1")]
    [InlineData("deada")]
    [InlineData("99")]
    public void MultiplyOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var multiplyOperator = new MultiplyOperator();
        var isMatch = multiplyOperator.IsValidCommand(command);

        Assert.False(isMatch, "Not wrong command for operator!");
    }

    [Fact]
    public void MultiplyOperator_Execute()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.StackMemory.Push(9);
        context.StackMemory.Push(6);
        var multiplyOperator = new MultiplyOperator();
        multiplyOperator.Execute(new("*"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(54, value);
    }
}
