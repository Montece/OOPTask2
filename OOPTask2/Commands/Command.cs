using OOPTask2.Commands.Arguments;

namespace OOPTask2.Commands;

public sealed class Command
{
    public string RawValue { get; }

    public CommandPrefix Prefix { get; }
    public Argument[] Arguments { get; }

    public Command(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        if (command.StartsWith('#'))
        {
            throw new ArgumentException("Cannot starts with #!", nameof(command));
        }

        RawValue = command;

        string prefixValue;
        if (command.Contains(' '))
        {
            prefixValue = command[..command.IndexOf(' ')];
            command = command[(command.IndexOf(' ') + 1)..];
        }
        else
        {
            prefixValue = command;
            command = string.Empty;
        }

        Prefix = new(prefixValue);

        if (!string.IsNullOrEmpty(command))
        {
            var arguments = command.Split(' ');
            Arguments = new Argument[arguments.Length];
            for (var i = 0; i < arguments.Length; i++)
            {
                Arguments[i] = ArgumentFabric.Create(arguments[i]);
            }
        }
        else
        {
            Arguments = [];
        }
    }
}