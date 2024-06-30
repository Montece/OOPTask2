using OOPTask2.Model;

namespace OOPTask2.Abstract;

public interface IOperator
{
    bool IsMatch(Command command);

    void Execute(Command command, IStackMemory memory);
}