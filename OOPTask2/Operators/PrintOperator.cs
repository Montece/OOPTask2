using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class PrintOperator : IOperator
{
    public string Prefix => "PRINT";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 0;
    }

    public void Execute(Command command, ICommandContext context)
    {
        var element = context.StackMemory.Pop();
        context.StackMemory.Push(element);
        context.CommandOutput.Write(element);
    }
}