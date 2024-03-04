using System.Reflection;
using System.Text;

namespace MailsSender.Core.Helpers
{
    public class EmbeddedResourcesReader
    {
        public static string[] GetList()
        {
            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            return names;
        }

        public static string GetAsUtf8String(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var resourceFullPath = $"{assemblyName}.{resourceName}";
            using var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(resourceFullPath)!;

            if (stream == null) {
                throw new Exception($"Embedded Resource not found: '{resourceFullPath}'.");
            }

            using var streamReader = new StreamReader(stream, Encoding.UTF8);
            var result = streamReader.ReadToEnd();
            return result;
        }
    }
}
