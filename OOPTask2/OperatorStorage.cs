using JetBrains.Annotations;
using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Operators;

namespace OOPTask2;

public sealed class OperatorStorage : IOperatorStorage
{
    public IOperatorLoader OperatorLoader { get; }
    public IOperatorCreator OperatorCreator { get; }

    private readonly List<IOperator> _operators = [];

    public OperatorStorage(IOperatorLoader operatorLoader, IOperatorCreator operatorCreator)
    {
        OperatorLoader = operatorLoader;
        OperatorCreator = operatorCreator;

        var classNames = operatorLoader.LoadClassNames();
        foreach (var className in classNames)
        {
            var newOperator = OperatorCreator.Create(className);
            _operators.Add(newOperator);
        }
    }

    [Pure]
    public IOperator? FindOperator(Command command)
    {
        var validOperator = _operators.FirstOrDefault(o => o.IsValidCommand(command));

        return validOperator;
    }
}

public interface IOperatorStorage
{
    public IOperatorLoader OperatorLoader { get; }
    public IOperatorCreator OperatorCreator { get; }

    public IOperator? FindOperator(Command command);
}
