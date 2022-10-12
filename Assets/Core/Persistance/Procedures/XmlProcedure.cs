using System.IO;
using System.Xml.Serialization;

namespace Multiscan.Persistance.Procedures
{
    public class XmlProcedure : IProcedure
    {
        public string filepath { get; set; }

        public TModel encode<TModel>()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(TModel));
            using FileStream stream = File.OpenRead(filepath);
            return (TModel)deserializer.Deserialize(stream);
        }

        public void decode<TModel>(TModel model)
        {
            var serializer = new XmlSerializer(typeof(TModel));
            using FileStream stream = File.OpenWrite(filepath);
            serializer.Serialize(stream, model);
        }
    }
}
