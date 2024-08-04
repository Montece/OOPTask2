using OOPTask2.Abstract;
using OOPTask2.Commands;

namespace OOPTask2.Console;

internal sealed class ConsoleReader : ICommandReader
{
    public bool HasCommands => true;

    private Queue<Command> _commandsBuffer = new();

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

            switch (upperCommandString)
            {
                case "EXIT":
                case "STOP":
                case "QUIT":
                    Environment.Exit(0);
                    return null;
                case "CLS":
                case "CLR":
                case "CLEAR":
                    System.Console.Clear();
                    return null;
                case "MEM":
                {
                    System.Console.WriteLine("===== STACK =====");
                    foreach (var element in Program.Interpreter?.CommandContext.StackMemory.GetMemoryState()!)
                    {
                        System.Console.WriteLine(element);
                    }
                    System.Console.WriteLine("===== PARAMETERS =====");
                    foreach (var parameter in Program.Interpreter.CommandContext.ParametersMemory.GetMemoryState())
                    {
                        System.Console.WriteLine(parameter);
                    }
                    return null;
                }
            }

            if (upperCommandString.StartsWith("EXECUTE "))
            {
                var fileInfo = new FileInfo(upperCommandString[8..]);
                foreach (var lineWithCommand in File.ReadAllLines(fileInfo.FullName))
                {
                    if (lineWithCommand.StartsWith('#'))
                    {
                        continue;
                    }

                    try
                    {
                        _commandsBuffer.Enqueue(new Command(lineWithCommand)); 
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine($"Error: {ex.Message} ({lineWithCommand})");
                    }
                }
                return null;
            }

            var command = new Command(rawCommandString);
            return command;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error! {ex.Message}");
            return null;
        }
    }
}