﻿using Moq;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class AddOperatorTests
{
    [Fact]
    public void AddOperator_IsMatch()
    {
        var command = new Command("+");
        var addOperator = new AddOperator();
        var isMatch = addOperator.IsValidCommand(command);

        Assert.True(isMatch, "Wrong command for operator!");
    }

    [Theory]
    [InlineData("5 + 4")]
    [InlineData("+ 1")]
    [InlineData("deada")]
    [InlineData("99")]
    public void AddOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var addOperator = new AddOperator();
        var isMatch = addOperator.IsValidCommand(command);

        Assert.False(isMatch, "Not wrong command for operator!");
    }

    [Fact]
    public void AddOperator_Execute()
    {
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), new Mock<ICommandOutput>().Object);
        context.StackMemory.Push(9);
        context.StackMemory.Push(6);
        var addOperator = new AddOperator();
        addOperator.Execute(new("+"), context);

        var value = context.StackMemory.Pop();
        Assert.Equal(15, value);
    }
}
