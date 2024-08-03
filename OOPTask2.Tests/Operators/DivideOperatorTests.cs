using Moq;
using OOPTask2.Abstract;
using OOPTask2.Memory;
using OOPTask2.Model;
using OOPTask2.Operators;
using OOPTask2.Operators.Divide;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class DivideOperatorTests
{
    [Fact]
    public void DivideOperator_IsMatch()
    {
        var command = new Command("/");
        var divideOperator = new DivideOperator();
        var isMatch = divideOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("5 / 4")]
    [InlineData("/ 1")]
    [InlineData("deada")]
    [InlineData("99")]
    public void DivideOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var divideOperator = new DivideOperator();
        var isMatch = divideOperator.IsMatch(command);

        Assert.False(isMatch);
    }

    [Fact]
    public void DivideOperator_Execute()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        new PushOperator().Execute(new("PUSH 999"), context);
        new PushOperator().Execute(new("PUSH 3"), context);
        new DivideOperator().Execute(new("/"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(333, value);
    }
}
