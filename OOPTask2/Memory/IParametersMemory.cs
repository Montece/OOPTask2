using OOPTask2.Commands;

namespace OOPTask2.Memory;

public interface IParametersMemory
{
    public void Set(Parameter parameter);

    public Parameter Get(string name);

    public bool IsExists(string name);

    IReadOnlyCollection<Parameter> GetMemoryState();
}