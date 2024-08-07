namespace OOPTask2.Console.ConsoleCommands;

public static class ConsoleCommandsManager
{
    public static bool IsInitialized { get; private set; }

    private static ConsoleCommand[]? _commands;

    public static void Initialize(ConsoleCommand[] commands)
    {
        if (IsInitialized)
        {
            return;
        }

        ArgumentNullException.ThrowIfNull(commands);

        _commands = commands;

        IsInitialized = true;
    }

    public static bool TryExecuteCommand(string upperCommandString, ConsoleReader consoleReader)
    {
        if (!IsInitialized || _commands is null)
        {
            return false;
        }

        return _commands.Select(command => command.TryExecute(upperCommandString, consoleReader)).Any(result => result);
    }
}