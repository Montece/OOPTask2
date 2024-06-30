using System.Text;
using Xunit;

namespace OOPTask2.Tests;

public sealed class CommandInterpreterTests
{
    [Fact]
    public void CommandInterpreter_ExecuteNextCommand()
    {
        var operatorCreator = new OperatorCreator();
        var operatorLoader = new JsonOperatorLoader();
        var memory = new StackMemory();
        var script = File.ReadAllText("script.txt");
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(script));
        var reader = new StreamReader(stream);
        var commandReader = new CommandReader(reader);

        var interpreter = new CommandInterpreter(operatorLoader, operatorCreator, memory, commandReader);

        interpreter.ExecuteAll();
    }
}