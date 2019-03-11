using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MunicipalitiesTax.Domain.Helpers
{
    public static class ByteToJson
    {
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);

            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}
