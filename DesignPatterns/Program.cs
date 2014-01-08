
using System;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Address myAddress = new Address("N. Murphy",
                                            "850 Massachusetts Ave.",
                                            "Apt #5",
                                            "Cambridge",
                                            "Massachusetts",
                                            string.Empty,
                                            "02139");

            Serializer xmlSerializer = new Serializer(new SerializerForXml());
            Serializer jsonSerializer = new Serializer(new SerializerForJson());

            Console.WriteLine(xmlSerializer.SerializeToString(myAddress));
            Console.WriteLine(jsonSerializer.SerializeToString(myAddress));
        }
    }
}
