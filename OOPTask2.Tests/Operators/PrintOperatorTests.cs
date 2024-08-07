using OOPTask2.Commands;
using OOPTask2.Operators;
using Xunit;

namespace OOPTask2.Tests.Operators;

public sealed class PrintOperatorTests
{
    [Fact]
    public void PrintOperator_IsMatch()
    {
        var command = new Command("PRINT");
        var printOperator = new PrintOperator();
        var isMatch = printOperator.IsValidCommand(command);

        Assert.True(isMatch, "Wrong command for operator!");
    }

    [Theory]
    [InlineData("PRINT 123")]
    public void PrintOperator_IsNotMatch(string commandString)
    {
        var command = new Command(commandString);
        var printOperator = new PrintOperator();
        var isMatch = printOperator.IsValidCommand(command);

        Assert.False(isMatch, "Not wrong command for operator!");
    }

    [Fact]
    public void PrintOperator_Execute()
    {
        var outputStream = new MemoryStream();
        var writer = new StreamWriter(outputStream);
        var commandOutput = new CommandOutput(writer);
        var context = new CommandContext(new StackMemory(), new ParametersMemory(), commandOutput);
        context.StackMemory.Push(99);
        var printOperator = new PrintOperator();
        printOperator.Execute(new("PRINT"), context);

        writer.Flush();
        outputStream.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(outputStream);
        var readElementFromMemory = reader.ReadLine();
        Assert.Equal("99", readElementFromMemory);
    }
}
