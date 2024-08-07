using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

public interface IOperator
{
    public string Prefix { get; }
    public int MinArgumentsCount { get; }
    public int MaxArgumentsCount { get; }

    bool IsValidCommand(Command command);

    void Execute(Command command, ICommandContext context);
}