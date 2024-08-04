using OOPTask2.Memory;
using OOPTask2.Model;

namespace OOPTask2;

public sealed class ParametersMemory : IParametersMemory
{
    private readonly List<Parameter> _parameters = [];

    public void Set(Parameter parameter)
    {
        var existsParameter = _parameters.FirstOrDefault(p => p.Name.Equals(parameter.Name));
        
        if (existsParameter is not null)
        {
            existsParameter.Value = parameter.Value;
        }
        else
        {
            _parameters.Add(parameter);
        }
    }

    public Parameter Get(string name)
    {
        var existsParameter = _parameters.FirstOrDefault(p => p.Name.Equals(name));

        if (existsParameter is not null)
        {
            return existsParameter;
        }
        else
        {
            throw new Exception($"Parameter {name} doesn't exists!");
        }
    }

    public bool IsExists(string name)
    {
        var isExistsParameter = _parameters.Any(p => p.Name.Equals(name));
        return isExistsParameter;
    }

    public IReadOnlyCollection<Parameter> GetMemoryState() => _parameters.ToArray();
}