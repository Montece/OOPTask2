using OOPTask2.Abstract;

namespace OOPTask2;

public sealed class CommandOutput(StreamWriter writer) : ICommandOutput
{
    public void Write(object data) => writer.WriteLine(data);
}