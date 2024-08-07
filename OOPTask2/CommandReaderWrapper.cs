using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2;

public sealed class CommandReaderWrapper : ICommandReader
{
    public bool HasCommands => !_reader.EndOfStream;

    private readonly StreamReader _reader;

    public CommandReaderWrapper(StreamReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        _reader = reader;
    }

    public Command? Read()
    {
        if (!HasCommands)
        {
            return null;
        }

        var line = _reader.ReadLine();

        if (string.IsNullOrEmpty(line) || line.StartsWith('#'))
        {
            return null;
        }

        var command = new Command(line);
            
        return command;
    }
}