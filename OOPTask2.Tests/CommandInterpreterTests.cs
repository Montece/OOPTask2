using System.Text;
using Xunit;

namespace OOPTask2.Tests;

public sealed class CommandInterpreterTests
{
    [Theory]
    [InlineData("script_1.txt", 789)]
    [InlineData("script_2.txt", 99)]
    [InlineData("script_3.txt", 114)]
    public void CommandInterpreter_ExecuteAll(string scriptName, double expectedTopStackValue)
    {
        var operatorCreator = new OperatorCreator();
        var operatorLoader = new JsonOperatorLoader();
        var operatorStorage = new OperatorStorage(operatorLoader, operatorCreator);
        var memory = new StackMemory();
        var parametersMemory = new ParametersMemory();
        var outputStream = new MemoryStream();
        var writer = new StreamWriter(outputStream);
        var commandOutput = new CommandOutput(writer);
        var context = new CommandContext(memory, parametersMemory, commandOutput);
        var script = File.ReadAllText(scriptName);

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(script));
        using var reader = new StreamReader(stream);
        var commandReader = new CommandReaderWrapper(reader);

        var interpreter = new CommandInterpreter(operatorStorage, commandReader, context);

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
        var parametersMemory = new ParametersMemory();
        var outputStream = new MemoryStream();
        var writer = new StreamWriter(outputStream);
        var commandOutput = new CommandOutput(writer);
        var context = new CommandContext(memory, parametersMemory, commandOutput);
        var script = File.ReadAllText(scriptName);
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(script));
        using var reader = new StreamReader(stream);
        var commandReader = new CommandReaderWrapper(reader);

        var interpreter = new CommandInterpreter(operatorStorage, commandReader, context);

        interpreter.ExecuteNext();
        interpreter.ExecuteNext();

        Assert.Equal(expectedElementsCount, memory.ElementsCount);
    }
}