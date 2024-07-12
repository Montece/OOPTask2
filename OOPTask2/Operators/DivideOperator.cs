using OOPTask2.Abstract;
using OOPTask2.Exceptions;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed class DivideOperator : IOperator
{
    public string Prefix => "/";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 0;
    }

    public void Execute(Command command, ICommandContext context)
    {
        var rightOperand = context.StackMemory.Pop();
        var leftOperand = context.StackMemory.Pop();

        if (rightOperand.Equals(0))
        {
            throw new ZeroDivideException();
        }

        var result = leftOperand / rightOperand;
        context.StackMemory.Push(result);
    }
}