using OOPTask2.Abstract;
using OOPTask2.Exceptions;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed class SquareRootOperator : IOperator
{
    public string Prefix => "SQRT";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 0;
    }

    public void Execute(Command command, ICommandContext context)
    {
        var operand = context.StackMemory.Pop();
        var sqrt = Math.Sqrt(operand);

        if (sqrt.Equals(double.NaN))
        {
            throw new SquareRootException($"Не удалось взять корень числа '{operand}'!");
        }

        context.StackMemory.Push(sqrt);
    }
}