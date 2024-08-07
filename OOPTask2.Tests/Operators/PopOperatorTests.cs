using Moq;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class PopOperatorTests
{
    [Theory]
    [InlineData("POP")]
    [InlineData("POP x")]
    public void PopOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var popOperator = new PopOperator();
        var isMatch = popOperator.IsValidCommand(command);

        Assert.True(isMatch, "Wrong command for operator!");
    }

    [Theory]
    [InlineData("А это не команда")]
    public void PopOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var popOperator = new PopOperator();
        var isMatch = popOperator.IsValidCommand(command);

        Assert.False(isMatch, "Not wrong command for operator!");
    }

    [Fact]
    public void PopOperator_ExecuteWithNumber()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new CommandOutput(null!));
        var popOperator = new PopOperator();
        new PushOperator().Execute(new("PUSH 99"), context);
        var countAfterPush = context.StackMemory.ElementsCount;
        popOperator.Execute(new("POP"), context);
        var countAfterPop = context.StackMemory.ElementsCount;

        Assert.True(countAfterPush == 1 && countAfterPop == 0, "Wrong count check!");
    }

    [Fact]
    public void PopOperator_ExecuteWithParameters()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.StackMemory.Push(76);
        new PopOperator().Execute(new("POP x"), context);
        var parameter = context.ParametersMemory.Get("x");

        Assert.Equal(76, parameter.Value);
    }
}
