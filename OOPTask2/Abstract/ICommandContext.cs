using OOPTask2.Memory;

namespace OOPTask2.Abstract;

public interface ICommandContext
{
    public IStackMemory StackMemory { get; }
    public IParametersMemory ParametersMemory { get; }

    public ICommandOutput CommandOutput { get; }
}