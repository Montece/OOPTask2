using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2;

public sealed class CommandReader(StreamReader reader) : ICommandReader
{
    public bool HasCommands => !reader.EndOfStream;

    public Command? Read()
    {
        var line = reader.ReadLine();

        if (string.IsNullOrEmpty(line) || line.StartsWith('#'))
        {
            return null;
        }

        var command = new Command(line);
            
        return command;
    }
}