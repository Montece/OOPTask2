using System.Text.RegularExpressions;
using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2.Operators;

public sealed partial class CommentOperator : IOperator
{
    public bool IsMatch(Command command)
    {
        return CommentRegex().IsMatch(command.Value);
    }

    public void Execute(Command command, IStackMemory memory)
    {
        // Nothing
    }

    [GeneratedRegex("^#.*")]
    private static partial Regex CommentRegex();
}