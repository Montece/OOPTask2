using Moq;
using OOPTask2.Abstract;
using OOPTask2.Model;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests;

public sealed class DefineOperatorTests
{
    [Theory]
    [InlineData("DEFINE x 5")]
    [InlineData("DEFINE y 66")]
    public void DefineOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var defineOperator = new DefineOperator();
        var isMatch = defineOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("DEFINE w")]
    [InlineData("DEFINE 12345")]
    public void DefineOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var defineOperator = new DefineOperator();
        var isMatch = defineOperator.IsMatch(command);

        Assert.False(isMatch);
    }

    [Fact]
    public void DefineOperator_Execute()
    {
        var command = new Command("DEFINE x 99");
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        var defineOperator = new DefineOperator();
        defineOperator.Execute(command, context);
        new PushOperator().Execute(new Command("PUSH x"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(99, value);
    }
}