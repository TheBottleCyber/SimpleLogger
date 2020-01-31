using Newtonsoft.Json;

namespace SimpleLogger.Formatters
{
    public class JSONFormatter : IFormatter
    {
        private JsonSerializerSettings _jsonSettings { get; }
        public JSONFormatter(JsonSerializerSettings jsonSettings = null) => _jsonSettings = jsonSettings ?? new JsonSerializerSettings();

        public string FormatMessage<T>(T message)
        {
            var serializationMessage = new SerializationMessage<T>(message);
            // I added a comma to make it convenient to look through https://jsonformatter.org/json-parser
            return $"{JsonConvert.SerializeObject(serializationMessage, _jsonSettings)},";
        }
    }
}
