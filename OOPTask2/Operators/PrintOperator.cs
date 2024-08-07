using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class PrintOperator : Operator
{
    public override string Prefix => "PRINT";
    public override int MinArgumentsCount => 0;
    public override int MaxArgumentsCount => 0;
    
    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 0:
                var element = context.StackMemory.Pop();
                context.StackMemory.Push(element);
                context.CommandOutput.Write(element);
                break;
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}