using Xunit;

namespace OOPTask2.Tests;

public sealed class CommandOutputTests
{
    [Fact]
    public void CommandOutput_Write()
    {
        var word = "Hello";
        var outputStream = new MemoryStream();
        var writer = new StreamWriter(outputStream);
        var commandOutput = new CommandOutput(writer);
        commandOutput.Write(word);
        writer.Flush();
        outputStream.Position = 0;
        var reader = new StreamReader(outputStream);
        var readLine = reader.ReadLine();

        Assert.Equal(word, readLine);
    }
}
