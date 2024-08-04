using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Commands.Arguments;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class PushOperator : IOperator
{
    public string Prefix => "PUSH";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 1;
    }

    public void Execute(Command command, ICommandContext context)
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
                    return;
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