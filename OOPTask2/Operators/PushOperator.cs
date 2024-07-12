using OOPTask2.Abstract;
using OOPTask2.Model;
using System.Text.RegularExpressions;

namespace OOPTask2.Operators;

public sealed partial class PushOperator : IOperator
{
    private const string PREFIX = "PUSH";
    
    public bool IsMatch(Command command)
    {
        return PushRegex().IsMatch(command.Value);
    }

    public void Execute(Command command, IStackMemory memory)
    {
        var valueStr = command.Value.Replace(PREFIX, string.Empty);
        if (double.TryParse(valueStr, out var value))
        {
            memory.Push(value);
        }
    }

    [GeneratedRegex($@"^{PREFIX} -?\d+(?:\.\d+)?")]
    private static partial Regex PushRegex();
}