using OOPTask2.Abstract;

namespace OOPTask2.Console;

internal sealed class ConsoleOutput : ICommandOutput
{
    public void Write(object data)
    {
        System.Console.WriteLine(data);
    }
}