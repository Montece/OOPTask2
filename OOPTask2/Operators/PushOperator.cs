using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Commands.Arguments;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class PushOperator : Operator
{
    public override string Prefix => "PUSH";
    public override int MinArgumentsCount => 1;
    public override int MaxArgumentsCount => 1;

    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 1 when command.Arguments[0] is NumberArgument numberArgument:
                context.StackMemory.Push((double)numberArgument.Value);
                break;
            case 1 when command.Arguments[0] is ParameterArgument parameterArgument:
            {
                if (!context.ParametersMemory.IsExists((string)parameterArgument.Value))
                {
                    throw new ArgumentNotExistException();
                }
                var parameter = context.ParametersMemory.Get((string)parameterArgument.Value);
                context.StackMemory.Push(parameter.Value);
                break;
            }
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}