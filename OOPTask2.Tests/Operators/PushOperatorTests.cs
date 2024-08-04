using Moq;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class PushOperatorTests
{
    [Theory]
    [InlineData("PUSH 0,0")]
    [InlineData("PUSH 8")]
    public void PushOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var pushOperator = new PushOperator();
        var isMatch = pushOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("А это не команда")]
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
    public void PushOperator_ExecuteWithNumber(string commandString, double expectedValue)
    {
        var command = new Command(commandString);
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new CommandOutput(null!));
        var pushOperator = new PushOperator();
        pushOperator.Execute(command, context);

        var value = context.StackMemory.Pop();
        Assert.Equal(expectedValue, value);
    }

    [Fact]
    public void PushOperator_ExecuteWithParameters()
    {
        var command = new Command("PUSH a");
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.ParametersMemory.Set(new Parameter("a", 8));
        var pushOperator = new PushOperator();
        pushOperator.Execute(command, context);

        var value = context.StackMemory.Pop();
        Assert.Equal(8, value);
    }
}
