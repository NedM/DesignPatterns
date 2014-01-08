using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace DesignPatterns
{
    public class SerializerForXml : ISerializeStrategy
    {
        private XmlWriterSettings _settings;

        public SerializerForXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    ",
                    OmitXmlDeclaration = true,
                    NamespaceHandling = NamespaceHandling.OmitDuplicates
                };

            Initialize(settings);
        }

        public SerializerForXml(XmlWriterSettings settings)
        {
            Initialize(settings);
        }

        public void Serialize(object objToSerialize, string outputPath)
        {
            DataContractSerializer dcs = new DataContractSerializer(objToSerialize.GetType());

            using (XmlWriter writer = XmlWriter.Create(outputPath, _settings))
            {
                dcs.WriteObject(writer, objToSerialize);
            }
        }

        public string SerializeToString(object objToSerialize)
        {
            StringBuilder builder = new StringBuilder();
            DataContractSerializer dcs = new DataContractSerializer(objToSerialize.GetType());
            
            using (XmlWriter writer = XmlWriter.Create(builder, _settings))
            {
                dcs.WriteObject(writer, objToSerialize);
            }

            return builder.ToString();
        }

        private void Initialize(XmlWriterSettings settings)
        {
            _settings = settings;
        }
    }
}
