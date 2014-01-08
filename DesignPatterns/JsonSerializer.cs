using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace DesignPatterns
{
    public class SerializerForJson : ISerializeStrategy
    {
        private JsonSerializer _serializer;

        public SerializerForJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                };

            Initialize(settings);
        }

        public SerializerForJson(JsonSerializerSettings settings)
        {
            Initialize(settings);
        }

        public void Serialize(object objToSerialize, string outputPath)
        {
            using (TextWriter writer = new StreamWriter(outputPath))
            {
                _serializer.Serialize(writer, objToSerialize);
            }
        }

        public string SerializeToString(object objToSerialize)
        {
            StringBuilder builder = new StringBuilder();

            using (StringWriter writer = new StringWriter(builder))
            {
                _serializer.Serialize(writer, objToSerialize);
            }

            return builder.ToString();
        }

        private void Initialize(JsonSerializerSettings settings)
        {
            _serializer = JsonSerializer.Create(settings);
        }
    }
}
