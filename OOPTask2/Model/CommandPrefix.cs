namespace OOPTask2.Model;

public sealed class CommandPrefix
{
    public string Value { get; }

    public CommandPrefix(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);

        if (value.Contains(' '))
        {
            throw new ArgumentException("Cannot contains whitespaces!", nameof(value));
        }

        Value = value;
    }
}