using Medic.Formatters.Contracts;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Medic.Formatters
{
    public class JsonFormatter : IDataFormattable
    {
        public string MimeType => "application/json";

        public async Task<string> FormatObject(object model)
        {
            if (model == default)
            {
                return default;
            }

            return await Task.Run(() => {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                return JsonConvert.SerializeObject(model, jsonSerializerSettings); 
            });
        }
    }
}
