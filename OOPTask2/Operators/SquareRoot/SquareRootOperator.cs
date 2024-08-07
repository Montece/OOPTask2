using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators.SquareRoot;

[UsedImplicitly]
public sealed class SquareRootOperator : Operator
{
    public override string Prefix => "SQRT";
    public override int MinArgumentsCount => 0;
    public override int MaxArgumentsCount => 0;

    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 0:
                var operand = context.StackMemory.Pop();
                var sqrt = Math.Sqrt(operand);

                if (sqrt.Equals(double.NaN))
                {
                    throw new SquareRootException($"Cannot take the square root of '{operand}'!");
                }

                context.StackMemory.Push(sqrt);
                break;
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}