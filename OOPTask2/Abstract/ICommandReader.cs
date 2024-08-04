using OOPTask2.Commands;

namespace OOPTask2.Abstract;

public interface ICommandReader
{
    public bool HasCommands { get; }

    public Command? Read();
}