using OOPTask2.Commands.Arguments;

namespace OOPTask2.Model;

public sealed class Parameter
{
    public string Name { get; }
    public double Value { get; set; }

    public Parameter(string name, double value)
    {
        if (string.IsNullOrEmpty(name) || !ArgumentFabric.IsText(name))
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
}