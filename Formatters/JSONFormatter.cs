using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleLogger.Formatters
{
    public class JSONFormatter : IFormatter
    {
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings();
        public JSONFormatter(JsonSerializerSettings jsonSettings = null) => _jsonSettings = jsonSettings;

        public string FormatMessage<T>(T message)
        {
            var serializationMessage = new SerializationMessage<T>(message);
            return $"{JsonConvert.SerializeObject(serializationMessage, _jsonSettings)},";
        }
    }
}
