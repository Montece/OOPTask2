using System.Text.RegularExpressions;

namespace OOPTask2.Model;

public sealed partial class Parameter
{
    public string Name { get; set; }
    public double Value { get; set; }

    public Parameter(string name, double value)
    {
        if (string.IsNullOrEmpty(name) || !ParameterRegex().IsMatch(name))
        {
            throw new ArgumentException("Not valid!", nameof(name));
        }

        if (value.Equals(double.NaN))
        {
            throw new ArgumentException("Cannot be NaN!", nameof(value));
        }

        Name = name;
        Value = value;
    }

    public override string ToString() => $"{Name}={Value}";

    [GeneratedRegex("^[a-zA-Z_][a-zA-Z0-9_]*$")]
    public static partial Regex ParameterRegex();
}