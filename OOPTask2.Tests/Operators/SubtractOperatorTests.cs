using Moq;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class SubtractOperatorTests
{
    [Fact]
    public void SubtractOperator_IsMatch()
    {
        var command = new Command("-");
        var subtractOperator = new SubtractOperator();
        var isMatch = subtractOperator.IsMatch(command);

        Assert.True(isMatch, "Wrong command for operator!");
    }

    [Theory]
    [InlineData("5 - 4")]
    [InlineData("- 1")]
    [InlineData("deada")]
    [InlineData("99")]
    public void SubtractOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var subtractOperator = new SubtractOperator();
        var isMatch = subtractOperator.IsMatch(command);

        Assert.False(isMatch, "Not wrong command for operator!");
    }

    [Fact]
    public void SubtractOperator_Execute()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.StackMemory.Push(9);
        context.StackMemory.Push(6);
        var subtractOperator = new SubtractOperator();
        subtractOperator.Execute(new("-"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(3, value);
    }
}
