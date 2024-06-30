using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2;

public sealed class CommandReader(StreamReader reader) : ICommandReader
{
    public bool HasCommands => !reader.EndOfStream;

    public Command? Read()
    {
        var line = reader.ReadLine();

        if (line is null)
        {
            return null;
        }

        var command = new Command(line);
            
        return command;
    }
}