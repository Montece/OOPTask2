using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Operators;

[UsedImplicitly]
public sealed class DefineOperator : Operator
{
    public override string Prefix => "DEFINE";
    public override int MinArgumentsCount => 2;
    public override int MaxArgumentsCount => 2;

    protected override void ExecuteInternal(Command command, ICommandContext context)
    {
        switch (command.Arguments.Length)
        {
            case 2:
                var name = (string)command.Arguments[0].Value;
                var value = (double)command.Arguments[1].Value;
                context.ParametersMemory.Set(new(name, value));
                break;
            default:
                throw new InvalidArgumentsCountException();
        }
    }
}