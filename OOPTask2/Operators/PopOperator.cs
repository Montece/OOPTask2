using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Commands.Arguments;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class PopOperator : Operator
{
    public override string Prefix => "POP";
    public override int MinArgumentsCount => 0;
    public override int MaxArgumentsCount => 1;

    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 0:
                context.StackMemory.Pop();
                break;
            case 1:
            {
                if (command.Arguments[0] is ParameterArgument parameterArgument)
                {
                    var name = (string)parameterArgument.Value;
                    var value = context.StackMemory.Pop();
                    context.ParametersMemory.Set(new(name, value));
                }
                break;
            }
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}