using System.IO;
using System.Runtime.Serialization.Json;

namespace WebApiDemo_5Sept19
{
    public static class ObjectSerializer
    {
        public static string Serialize(this object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
