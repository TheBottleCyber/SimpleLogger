using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
