using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

public abstract class Operator : IOperator
{
    public abstract string Prefix { get; }
    public abstract int MinArgumentsCount { get; }
    public abstract int MaxArgumentsCount { get; }

    public bool IsValidCommand(Command command)
    {
        return
            command.Prefix.Value.Equals(Prefix) &&
            MinArgumentsCount <= MaxArgumentsCount &&
            command.Arguments.Length >= MinArgumentsCount &&
            command.Arguments.Length <= MaxArgumentsCount;
    }

    public void Execute(Command command, ICommandContext context)
    {
        if (!IsValidCommand(command))
        {
            throw new MismatchOperatorCommandException();
        }

        ExecuteInternal(command, context);
    }

    protected abstract void ExecuteInternal(Command command, ICommandContext context);
}