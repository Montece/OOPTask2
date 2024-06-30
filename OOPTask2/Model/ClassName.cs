using Newtonsoft.Json;
using OOPTask2.Utility;

namespace OOPTask2.Model;

public sealed class ClassName
{
    [JsonProperty("Value")]
    public string Value { get; private set; }

    [JsonProperty("AssemblyFullname")]
    public string AssemblyFullname { get; private set; } = string.Empty;

    [JsonConstructor]
    private ClassName()
    {
        Value = string.Empty;
    }

    public ClassName(string fullname)
    {
        if (!DomainHelper.IsTypeExists(fullname, out _))
        {
            throw new ArgumentException("Не существует такого типа в сборке!", nameof(fullname));
        }

        Value = fullname;
    }
}