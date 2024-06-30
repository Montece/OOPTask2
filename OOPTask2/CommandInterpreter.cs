using NLog;
using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2;

public sealed class CommandInterpreter : ICommandInterpreter
{
    public IOperatorLoader OperatorLoader { get; }
    public IOperatorCreator OperatorCreator { get; }
    public IStackMemory StackMemory { get; }
    public ICommandReader CommandReader { get; }

    private readonly List<IOperator> _operators = [];

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public bool HasNextCommand => CommandReader.HasCommands;

    public CommandInterpreter(IOperatorLoader operatorLoader, IOperatorCreator operatorCreator, IStackMemory stackMemory, CommandReader commandReader)
    {
        OperatorLoader = operatorLoader;
        OperatorCreator = operatorCreator;
        StackMemory = stackMemory;
        CommandReader = commandReader;

        var classNames = operatorLoader.LoadClassNames();
        foreach (var className in classNames)
        {
            var newOperator = OperatorCreator.Create(className);
            _operators.Add(newOperator);
        }
    }

    public void ExecuteNext()
    {
        var command = CommandReader.Read();

        if (command is null)
        {
            _logger.Warn($"Command '{command}' is null");
            return;
        }

        var matchOperator = AnyOperatorMatch(command);

        if (matchOperator is null)
        {
            _logger.Warn($"Where is no match operator for command '{command}'");
            return;
        }

        matchOperator.Execute(command, StackMemory);
    }

    public void ExecuteAll()
    {
        while (HasNextCommand)
        { 
            ExecuteNext();
        }
    }

    private IOperator? AnyOperatorMatch(Command command)
    {
        var matchOperator = _operators.FirstOrDefault(o => o.IsMatch(command));

        return matchOperator;
    }
}