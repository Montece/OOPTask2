using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class MultiplyOperator : Operator
{
    public override string Prefix => "*";
    public override int MinArgumentsCount => 0;
    public override int MaxArgumentsCount => 0;

    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 0:
                var rightOperand = context.StackMemory.Pop();
                var leftOperand = context.StackMemory.Pop();
                var result = leftOperand * rightOperand;
                context.StackMemory.Push(result);
                break;
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}