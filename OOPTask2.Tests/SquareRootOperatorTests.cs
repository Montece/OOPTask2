using Moq;
using OOPTask2.Abstract;
using OOPTask2.Model;
using OOPTask2.Operators.SquareRoot;
using Xunit;

namespace OOPTask2.Tests;

public sealed class SquareRootOperatorTests
{
    [Theory]
    [InlineData("SQRT")]
    public void SquareRootOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var squareRootOperator = new SquareRootOperator();
        var isMatch = squareRootOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("# А это не команда")]
    [InlineData("SQRT 1")]
    public void SquareRootOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var squareRootOperator = new SquareRootOperator();
        var isMatch = squareRootOperator.IsMatch(command);

        Assert.False(isMatch);
    }

    [Fact]
    public void SquareRootOperator_Execute()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.StackMemory.Push(64);
        var squareRootOperator = new SquareRootOperator();
        squareRootOperator.Execute(new("SQRT"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(8, value);
    }
}
