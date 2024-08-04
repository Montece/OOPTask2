using OOPTask2.Commands;
using Xunit;

namespace OOPTask2.Tests.Commands;

public sealed class CommandTests
{
    [Theory]
    [InlineData("123")]
    [InlineData("ЕщеОдинТест123")]
    [InlineData("Test-")]
    public void Сommand_Create(string commandString)
    {
        var command = new Command(commandString);

        Assert.NotNull(command);
    }

    [Theory]
    [InlineData("#Тест")]
    [InlineData("")]
    public void Сommand_CannotCreate(string commandString)
    {
        Assert.Throws<ArgumentException>(() => new Command(commandString));
    }
}