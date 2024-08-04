using System.Text;
using OOPTask2.Commands;
using Xunit;

namespace OOPTask2.Tests;

public class CommandReaderTests
{
    [Theory]
    [InlineData("123\n456\n#74544faf\nghflhki\n\n", 3)]
    public void CommandReader_Read(string text, int validCommandsCount)
    {
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        var reader = new StreamReader(stream);
        var commandReader = new CommandReader(reader);

        var commands = new List<Command>();

        while (commandReader.HasCommands)
        {
            var command = commandReader.Read();

            if (command == null)
            {
                continue;
            }

            commands.Add(command);
        }

        Assert.Equal(validCommandsCount, commands.Count);
    }
}