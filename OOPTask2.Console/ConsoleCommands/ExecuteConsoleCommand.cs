namespace OOPTask2.Console.ConsoleCommands;

public class ExecuteConsoleCommand : ConsoleCommand
{
    public override bool TryExecute(string upperCommandString, ConsoleReader consoleReader)
    {
        const string executePrefix = "EXECUTE ";

        if (upperCommandString.StartsWith(executePrefix))
        {
            var fileInfo = new FileInfo(upperCommandString[executePrefix.Length..]);
            foreach (var lineWithCommand in File.ReadAllLines(fileInfo.FullName))
            {
                if (lineWithCommand.StartsWith('#'))
                {
                    continue;
                }

                try
                {
                    consoleReader.AddCommandToBuffer(new(lineWithCommand));
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message} ({lineWithCommand})");
                }
            }

            return true;
        }

        return false;
    }
}