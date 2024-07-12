using System.Text;
using Xunit;

namespace OOPTask2.Tests;

public sealed class CommandInterpreterTests
{
    [Theory]
    [InlineData("script_1.txt", 789)]
    [InlineData("script_2.txt", 99)]
    public void CommandInterpreter_ExecuteAll(string scriptName, double expectedTopStackValue)
    {
        var operatorCreator = new OperatorCreator();
        var operatorLoader = new JsonOperatorLoader();
        var operatorStorage = new OperatorStorage(operatorLoader, operatorCreator);
        var memory = new StackMemory();
        var script = File.ReadAllText(scriptName);
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(script));
        var reader = new StreamReader(stream);
        var commandReader = new CommandReader(reader);

        var interpreter = new CommandInterpreter(operatorStorage, memory, commandReader);

        interpreter.ExecuteAll();
        var topStackValue = memory.Pop();

        Assert.Equal(expectedTopStackValue, topStackValue);
    }

    [Theory]
    [InlineData("script_1.txt", 1)]
    [InlineData("script_2.txt", 1)]
    public void CommandInterpreter_ExecuteNext(string scriptName, int expectedElementsCount)
    {
        var operatorCreator = new OperatorCreator();
        var operatorLoader = new JsonOperatorLoader();
        var operatorStorage = new OperatorStorage(operatorLoader, operatorCreator);
        var memory = new StackMemory();
        var script = File.ReadAllText(scriptName);
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(script));
        var reader = new StreamReader(stream);
        var commandReader = new CommandReader(reader);

        var interpreter = new CommandInterpreter(operatorStorage, memory, commandReader);

        interpreter.ExecuteNext();
        interpreter.ExecuteNext();

        Assert.Equal(expectedElementsCount, memory.ElementsCount);
    }
}