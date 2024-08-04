using NLog;
using OOPTask2.Abstract;

namespace OOPTask2;

public sealed class CommandInterpreter(IOperatorStorage operatorStorage, ICommandReader commandReader, ICommandContext commandContext) : ICommandInterpreter
{
    public IOperatorStorage OperatorStorage { get; } = operatorStorage;
    public ICommandReader CommandReader { get; } = commandReader;
    public ICommandContext CommandContext { get; } = commandContext;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public bool HasNextCommand => CommandReader.HasCommands;

    public void ExecuteNext()
    {
        var command = CommandReader.Read();

        if (command is null)
        {
            Logger.Warn($"Command '{command}' is null");
            return;
        }

        var matchOperator = OperatorStorage.FindOperator(command);

        if (matchOperator is null)
        {
            Logger.Warn($"Where is no match operator for command '{command}'");
            return;
        }

        Logger.Info($"Execute command '{command.RawValue}'");

        try
        {
            matchOperator.Execute(command, CommandContext);
        }
        catch (Exception ex)
        {
            // ReSharper disable once StructuredMessageTemplateProblem
            Logger.Error("Error while executing command!", ex);
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