using OOPTask2.Abstract;
using OOPTask2.Exceptions;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed class SquareRootOperator : IOperator
{
    private const string PREFIX = "SQRT";

    public bool IsMatch(Command command)
    {
        return PREFIX.Equals(command.Value);
    }

    public void Execute(Command command, IStackMemory memory)
    {
        var element = memory.Pop();
        var sqrt = Math.Sqrt(element);

        if (sqrt.Equals(double.NaN))
        {
            throw new SquareRootException($"Не удалось взять корень числа '{element}'!");
        }

        memory.Push(sqrt);
    }
}