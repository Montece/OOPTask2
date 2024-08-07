namespace OOPTask2.Console.ConsoleCommands;

internal sealed class ShowMemoryConsoleCommand : ConsoleCommand
{
    public override bool TryExecute(string upperCommandString, ConsoleReader consoleReader)
    {
        switch (upperCommandString)
        {
            case "MEM":
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
                return true;
            default:
                return false;
        }
    }
}