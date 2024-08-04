using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

public interface IOperator
{
    public string Prefix { get; }

    bool IsMatch(Command command);

    void Execute(Command command, ICommandContext context);
}