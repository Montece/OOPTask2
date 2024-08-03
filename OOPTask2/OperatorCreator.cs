using OOPTask2.Abstract;
using OOPTask2.Operators;
using OOPTask2.Utility;

namespace OOPTask2;

public sealed class OperatorCreator : IOperatorCreator
{
    public IOperator Create(ClassName operatorFullName)
    {
        var instance = DomainHelper.CreateInstance(operatorFullName);

        if (instance is not IOperator iOperator)
        {
            throw new ArgumentException("Cannot create class!", nameof(operatorFullName));
        }

        return iOperator;
    }
}