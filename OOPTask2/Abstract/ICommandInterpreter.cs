namespace OOPTask2.Abstract;

public interface ICommandInterpreter
{
    public IOperatorStorage OperatorStorage { get; }
    public ICommandReader CommandReader { get; }
    public ICommandContext CommandContext { get; }
}