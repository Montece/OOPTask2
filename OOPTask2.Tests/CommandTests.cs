using OOPTask2.Model;
using Xunit;

namespace OOPTask2.Tests;

public sealed class CommandTests
{
    [Theory]
    [InlineData("123")]
    [InlineData("#Тест")]
    [InlineData("ЕщеОдинТест123")]
    [InlineData("Test-")]
    public void Сommand_Create(string commandString)
    {
        var command = new Command(commandString);

        Assert.NotNull(command);
    }

    [Fact]
    public void Сommand_Empty()
    {
        Assert.Throws<ArgumentException>(() => new Command(string.Empty));
    }
}