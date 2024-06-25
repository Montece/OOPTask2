using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2.Operators;

internal sealed class CommentOperator : IOperator
{
    public bool IsMatch(Command command)
    {
        return false;
    }

    public void Execute(IStackMemory memory)
    {

    }
}