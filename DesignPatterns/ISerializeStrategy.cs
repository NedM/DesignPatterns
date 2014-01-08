
namespace DesignPatterns
{
    public interface ISerializeStrategy
    {
        void Serialize(object objToSerialize, string outputPath);

        string SerializeToString(object objToSerialize);
    }
}
