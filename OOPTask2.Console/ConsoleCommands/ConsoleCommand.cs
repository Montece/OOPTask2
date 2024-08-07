namespace OOPTask2.Console.ConsoleCommands;

public abstract class ConsoleCommand
{
    public abstract bool TryExecute(string upperCommandString, ConsoleReader consoleReader);
}