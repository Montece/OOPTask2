using System.Text.RegularExpressions;
using OOPTask2.Model;
using OOPTask2.Model.Arguments;

namespace OOPTask2;

internal static partial class ArgumentFabric
{
    public static Argument Create(string argumentRawValue)
    {
        if (NumberArgumentRegex().IsMatch(argumentRawValue))
        {
            return new NumberArgument(double.Parse(argumentRawValue));
        }

        if (Parameter.ParameterRegex().IsMatch(argumentRawValue))
        {
            return new ParameterArgument(argumentRawValue);
        }

        if (StringArgumentRegex().IsMatch(argumentRawValue))
        {
            return new StringArgument(argumentRawValue);
        }

        return new UnknownArgument(argumentRawValue);
    }

    [GeneratedRegex(".*")]
    private static partial Regex StringArgumentRegex();

    [GeneratedRegex(@"-?\d+(?:\.\d+)?")]
    private static partial Regex NumberArgumentRegex();
}