namespace OOPTask2.Commands.Arguments;

public abstract class Argument(object value)
{
    public object Value { get; } = value;
}