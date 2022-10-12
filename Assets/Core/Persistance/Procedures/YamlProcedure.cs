using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Multiscan.Persistance.Procedures
{
    public class YamlProcedure : IProcedureReader
    {
        public string filepath { get; set; }

        public TModel encode<TModel>()
        {
            string plainYaml = File.ReadAllText(filepath);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            return deserializer.Deserialize<TModel>(plainYaml);
        }
    }
}
