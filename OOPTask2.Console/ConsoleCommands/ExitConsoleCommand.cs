namespace OOPTask2.Console.ConsoleCommands;

internal sealed class ExitConsoleCommand : ConsoleCommand
{
    public override bool TryExecute(string upperCommandString, ConsoleReader consoleReader)
    {
        switch (upperCommandString)
        {
            case "EXIT":
            case "STOP":
            case "QUIT":
                Environment.Exit(0);
                return true;
            default:
                return false;
        }
    }
}