namespace OOPTask2.Console;

internal static class Program
{
    public static CommandInterpreter Interpreter => _interpreter;
    private static CommandInterpreter _interpreter;

    public static void Main(string[] commandLineArguments)
    {
        System.Console.Title = "Calculator";

        var storage = new OperatorStorage(new JsonOperatorLoader(), new OperatorCreator());
        _interpreter = new CommandInterpreter(storage, new ConsoleReader(), new CommandContext(new StackMemory(), new ParametersMemory(), new ConsoleOutput()));

        _interpreter.ExecuteAll();
    }
}