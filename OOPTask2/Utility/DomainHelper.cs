using System.Reflection;
using JetBrains.Annotations;

namespace OOPTask2.Utility;

internal static class DomainHelper
{
    [Pure]
    public static bool IsTypeExists(string typeFullname, out string assemblyFullname)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        assemblyFullname = string.Empty;

        foreach (var assembly in assemblies)
        {
            try
            {
                if (assembly.GetType(typeFullname) is null || assembly.FullName is null)
                {
                    continue;
                }

                assemblyFullname = assembly.FullName;
                return true;
            }
            catch
            {
                // Ignored
            }
        }

        return false;
    }

    [Pure]
    [MustUseReturnValue]
    private static Assembly? GetAssemblyByName(string fullname)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var assemblyName = assembly.GetName().Name;

            if (assemblyName is null)
            {
                continue;
            }

            if (assemblyName.Equals(fullname))
            {
                return assembly;
            }
        }

        return null;
    }

    public static object CreateInstance(ClassName className)
    {
        var assembly = GetAssemblyByName(className.AssemblyFullname);

        if (assembly is null)
        {
            throw new Exception($"Сборка '{className.AssemblyFullname}' не загружена!");
        }

        var instance = assembly.CreateInstance(className.Value);

        if (instance is null)
        {
            throw new Exception($"Не удалось создать экземпляр класса '{className.Value}' из сборки '{className.AssemblyFullname}'!");
        }

        return instance;
    }
}