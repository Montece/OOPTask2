using OOPTask2.Operators;
using OOPTask2.Utility;

namespace OOPTask2.Abstract;

public interface IOperatorCreator
{
    IOperator Create(ClassName operatorFullName);
}