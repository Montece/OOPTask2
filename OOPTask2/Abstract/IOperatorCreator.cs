using OOPTask2.Model;

namespace OOPTask2.Abstract;

public interface IOperatorCreator
{
    IOperator Create(ClassName operatorFullName);
}