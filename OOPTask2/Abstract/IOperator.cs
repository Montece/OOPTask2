using OOPTask2.Model;

namespace OOPTask2.Abstract;

internal interface IOperator
{
    bool IsMatch(Command command);

    void Execute(IStackMemory memory);
}