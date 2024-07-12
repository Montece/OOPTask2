using NLog;
using OOPTask2.Abstract;

namespace OOPTask2;

public sealed class CommandInterpreter(IOperatorStorage operatorStorage, IStackMemory stackMemory, CommandReader commandReader) : ICommandInterpreter
{
    public IOperatorStorage OperatorStorage { get; } = operatorStorage;
    public IStackMemory StackMemory { get; } = stackMemory;
    public ICommandReader CommandReader { get; } = commandReader;

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public bool HasNextCommand => CommandReader.HasCommands;

    public void ExecuteNext()
    {
        var command = CommandReader.Read();

        if (command is null)
        {
            _logger.Warn($"Command '{command}' is null");
            return;
        }

        var matchOperator = OperatorStorage.FindOperator(command);

        if (matchOperator is null)
        {
            _logger.Warn($"Where is no match operator for command '{command}'");
            return;
        }

        _logger.Info($"Execute command '{command.Value}'");

        try
        {
            matchOperator.Execute(command, StackMemory);
        }
        catch (Exception ex)
        {
            _logger.Error($"Error while executing command!", ex);
        }
    }

    public void ExecuteAll()
    {
        while (HasNextCommand)
        { 
            ExecuteNext();
        }
    }
}