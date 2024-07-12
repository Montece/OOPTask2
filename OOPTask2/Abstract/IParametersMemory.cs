using OOPTask2.Model;

namespace OOPTask2.Abstract;

public interface IParametersMemory
{
    public void Set(Parameter parameter);

    public Parameter Get(string name);

    public bool IsExists(string name);

    IReadOnlyCollection<Parameter> GetMemoryState();
}