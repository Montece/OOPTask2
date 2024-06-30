using OOPTask2.Model;

namespace OOPTask2.Abstract;

public interface ICommandReader
{
    public bool HasCommands { get; }

    public Command? Read();
}