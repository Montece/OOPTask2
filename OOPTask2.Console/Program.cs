namespace OOPTask2.Console;

internal static class Program
{
    public static CommandInterpreter? Interpreter { get; private set; }

    public static void Main(string[] commandLineArguments)
    {
        System.Console.Title = "Calculator";

        var storage = new OperatorStorage(new JsonOperatorLoader(), new OperatorCreator());
        Interpreter = new CommandInterpreter(storage, new ConsoleReader(), new CommandContext(new StackMemory(), new ParametersMemory(), new ConsoleOutput()));

        Interpreter.ExecuteAll();
    }
}