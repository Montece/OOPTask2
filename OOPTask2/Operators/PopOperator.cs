using OOPTask2.Abstract;
using OOPTask2.Model;
using OOPTask2.Model.Arguments;

namespace OOPTask2.Operators;

public sealed class PopOperator : IOperator
{
    public string Prefix => "POP";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length is 0 or 1;
    }

    public void Execute(Command command, ICommandContext context)
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
                    var popValue = context.StackMemory.Pop();
                    context.ParametersMemory.Set(new((string)parameterArgument.Value, popValue));
                }
                break;
            }
        }
    }
}