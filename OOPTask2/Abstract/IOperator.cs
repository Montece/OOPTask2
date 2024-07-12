using OOPTask2.Model;

namespace OOPTask2.Abstract;

public interface IOperator
{
    public string Prefix { get; }

    bool IsMatch(Command command);

    void Execute(Command command, ICommandContext context);
}