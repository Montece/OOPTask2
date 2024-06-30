using Newtonsoft.Json;
using OOPTask2.Abstract;
using OOPTask2.Model;

namespace OOPTask2;

public sealed class JsonOperatorLoader : IOperatorLoader
{
    private const string FILENAME = "operators.json";

    public List<ClassName> LoadClassNames()
    {
        var json = File.ReadAllText(FILENAME);
        var classNames = JsonConvert.DeserializeObject<List<ClassName>>(json);

        if (classNames is null)
        {
            throw new Exception($"Не удалось прочитать файл '{FILENAME}'");
        }

        return classNames;
    }
}