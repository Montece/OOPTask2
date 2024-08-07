namespace OOPTask2.Console.ConsoleCommands;

internal sealed class ClearConsoleCommand : ConsoleCommand
{
    public override bool TryExecute(string upperCommandString, ConsoleReader consoleReader)
    {
        switch (upperCommandString)
        {
            case "CLS":
            case "CLR":
            case "CLEAR":
                System.Console.Clear();
                return true;
            default:
                return false;
        }
    }
}