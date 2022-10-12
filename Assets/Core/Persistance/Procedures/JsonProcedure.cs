using Newtonsoft.Json;
using System.IO;

namespace Multiscan.Persistance.Procedures
{
    public class JsonProcedure : IProcedure
    {
        public string filepath { get; set; }

        public TModel encode<TModel>()
        {
            string plainJson = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<TModel>(plainJson);
        }

        public void decode<TModel>(TModel model)
        {
            string plainJson = JsonConvert.SerializeObject(model);
            File.WriteAllText(filepath, plainJson);
        }
    }
}
