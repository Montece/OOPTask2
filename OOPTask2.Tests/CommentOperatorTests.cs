using OOPTask2.Model;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests;

public sealed class CommentOperatorTests
{
    [Theory]
    [InlineData("#Еще больший коммент")]
    [InlineData("#Коммент")]
    [InlineData("#Коммент???+-")]
    [InlineData("#English comment")]
    public void CommentOperator_IsMatch(string commandString)
    {
        var command = new Command(commandString);
        var commentOperator = new CommentOperator();
        var isMatch = commentOperator.IsMatch(command);

        Assert.True(isMatch);
    }

    [Theory]
    [InlineData("А это не коммент")]
    public void CommentOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var commentOperator = new CommentOperator();
        var isMatch = commentOperator.IsMatch(command);

        Assert.False(isMatch);
    }
}