using JetBrains.Annotations;
using Newtonsoft.Json;
using OOPTask2.Abstract;
using OOPTask2.Utility;

namespace OOPTask2;

public sealed class JsonOperatorLoader : IOperatorLoader
{
    private const string FILENAME = "operators.json";

    [MustUseReturnValue]
    public List<ClassName> LoadClassNames()
    {
        var json = File.ReadAllText(FILENAME);
        var classNames = JsonConvert.DeserializeObject<List<ClassName>>(json);

        if (classNames is null)
        {
            throw new Exception($"Cannot read file '{FILENAME}'");
        }

        return classNames;
    }
}