using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed class DefineOperator : IOperator
{
    public string Prefix => "DEFINE";

    public bool IsMatch(Command command)
    {
        return command.Prefix.Value.Equals(Prefix) && command.Arguments.Length == 2;
    }

    public void Execute(Command command, ICommandContext context)
    {
        context.ParametersMemory.Set(new((string)command.Arguments[0].Value, (double)command.Arguments[1].Value));
    }
}