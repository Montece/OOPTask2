using OOPTask2.Model;
using OOPTask2.Operators;
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
    [InlineData("#А это не команда")]
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
        var memory = new StackMemory();
        memory.Push(64);
        var squareRootOperator = new SquareRootOperator();
        squareRootOperator.Execute(new("SQRT"), memory);

        var value = memory.Pop();
        Assert.Equal(8, value);
    }
}
