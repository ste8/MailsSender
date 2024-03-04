using System.Collections;
using Newtonsoft.Json;

namespace MailsSender.Core.Helpers
{
    public class DynamicHelper
    {
        public static dynamic ToDynamic(IDictionary source)
        {
            var json = JsonConvert.SerializeObject(source);

            dynamic? dest = JsonConvert.DeserializeObject<dynamic>(json);
            if (dest == null) {
                throw new Exception("Cannot convert source to dynamic object.");
            }
            return dest;
        }
    }
}
