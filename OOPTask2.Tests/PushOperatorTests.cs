using OOPTask2.Model;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests;

public sealed class PushOperatorTests
{
    [Theory]
    [InlineData("PUSH 0.0")]
    [InlineData("PUSH 8")]
    public void PushOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var pushOperator = new PushOperator();
        var isMatch = pushOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("#А это не команда")]
    public void PushOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var pushOperator = new PushOperator();
        var isMatch = pushOperator.IsMatch(command);

        Assert.False(isMatch);
    }

    [Theory]
    [InlineData("PUSH 0,0", 0)]
    [InlineData("PUSH 8", 8)]
    public void PushOperator_Execute(string commandString, double expectedValue)
    {
        var command = new Command(commandString);
        var memory = new StackMemory();
        var pushOperator = new PushOperator();
        pushOperator.Execute(command, memory);

        var value = memory.Pop();
        Assert.Equal(expectedValue, value);
    }
}
