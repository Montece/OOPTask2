using Newtonsoft.Json;

namespace OOPTask2.Utility;

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
            throw new ArgumentException("The type doesn't exist in assembly!", nameof(fullname));
        }

        Value = fullname;
    }
}