using System;

namespace SimpleLogger.Formatters
{
    public class DefaultFormatter : IFormatter
    {
        public string FormatMessage<T>(T message)
        {
            return $"[{DateTime.Now}]: {message}\r\n";
        }
    }
}
