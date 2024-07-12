namespace OOPTask2.Abstract;

public interface ICommandInterpreter
{
    public IOperatorStorage OperatorStorage { get; }
    public IStackMemory StackMemory { get; }
    public ICommandReader CommandReader { get; }
}