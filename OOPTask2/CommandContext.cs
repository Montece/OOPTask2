using OOPTask2.Abstract;
using OOPTask2.Memory;

namespace OOPTask2;

public sealed class CommandContext(IStackMemory stackMemory, IParametersMemory parametersMemory, ICommandOutput commandOutput) : ICommandContext
{
    public IStackMemory StackMemory { get; } = stackMemory;
    public IParametersMemory ParametersMemory { get; } = parametersMemory;
    public ICommandOutput CommandOutput { get; } = commandOutput;
}