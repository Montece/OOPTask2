using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed class AddOperator : IOperator
{
    public string Prefix => "+";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 0;
    }

    public void Execute(Command command, ICommandContext context)
    {
        var rightOperand = context.StackMemory.Pop();
        var leftOperand = context.StackMemory.Pop();
        var result = leftOperand + rightOperand;
        context.StackMemory.Push(result);
    }
}