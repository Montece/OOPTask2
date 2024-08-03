namespace OOPTask2.Commands.Arguments;

public static class ArgumentFabric
{
    public static Argument Create(string argumentRawValue)
    {
        if (IsDouble(argumentRawValue))
        {
            return new NumberArgument(double.Parse(argumentRawValue));
        }

        if (IsParameter(argumentRawValue))
        {
            return new ParameterArgument(argumentRawValue);
        }

        if (IsText(argumentRawValue))
        {
            return new StringArgument(argumentRawValue);
        }

        return new UnknownArgument(argumentRawValue);
    }

    public static bool IsParameter(string rawString)
    {
        return !string.IsNullOrEmpty(rawString) && char.IsLetter(rawString[0]) && rawString.All(char.IsLetterOrDigit);
    }

    public static bool IsText(string rawString)
    {
        return !string.IsNullOrEmpty(rawString) && rawString.All(char.IsLetterOrDigit);
    }

    public static bool IsDouble(string rawString)
    {
        return !string.IsNullOrEmpty(rawString) && double.TryParse(rawString, out _);
    }
}