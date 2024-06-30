namespace OOPTask2.Abstract;

public interface ICommandInterpreter
{
    public IOperatorLoader OperatorLoader { get; }
    public IOperatorCreator OperatorCreator { get; }
    public IStackMemory StackMemory { get; }
    public ICommandReader CommandReader { get; }
}