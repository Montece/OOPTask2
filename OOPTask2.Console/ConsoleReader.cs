using OOPTask2.Abstract;
using OOPTask2.Commands;
using OOPTask2.Console.ConsoleCommands;

namespace OOPTask2.Console;

public sealed class ConsoleReader : ICommandReader
{
    public bool HasCommands => true;

    private readonly Queue<Command> _commandsBuffer = new();

    public Command? Read()
    {
        try
        {
            if (_commandsBuffer.Count != 0)
            {
                var commandToExecute = _commandsBuffer.Dequeue();
                System.Console.WriteLine($"SCRIPT > {commandToExecute.RawValue}");
                return commandToExecute;
            }

            System.Console.Write("> ");

            var rawCommandString = System.Console.ReadLine();

            if (rawCommandString == null)
            {
                return null;
            }

            var upperCommandString = rawCommandString.ToUpper();

            var result = ConsoleCommandsManager.TryExecuteCommand(upperCommandString, this);

            if (!result)
            {
                var command = new Command(rawCommandString);
                return command;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error! {ex.Message}");
        }

        return null;
    }

    public void AddCommandToBuffer(Command command)
    {
        _commandsBuffer.Enqueue(command);
    }
}