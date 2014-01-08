using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    public class Serializer
    {
        private readonly ISerializeStrategy _strategy;

        public Serializer(ISerializeStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void Serialize(object objectToSerialize, string outputPath)
        {
            _strategy.Serialize(objectToSerialize, outputPath);
        }

        public string SerializeToString(object objectToSerialize)
        {
            return _strategy.SerializeToString(objectToSerialize);
        }
    }
}
