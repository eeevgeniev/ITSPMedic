using Medic.Formatters.Contracts;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace Medic.Formatters.Implementors
{
    public class JsonFormatter : IDataFormattable
    {
        public string MimeType => "application/json";

        public async Task<Stream> FormatObject(object model, Stream stream)
        {
            if (model == default)
            {
                return default;
            }

            return await Task<Stream>.Run(() => {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                JsonSerializer jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);

                JsonTextWriter jsonTextWriter = new JsonTextWriter(new StreamWriter(stream));

                jsonSerializer.Serialize(jsonTextWriter, model);

                jsonTextWriter.Flush();

                return stream;
            });
        }
    }
}
