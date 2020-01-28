using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Interfaces
{
    public class DefaultFormatter : IFormatter
    {
        public string FormatMessage<T>(T message)
        {
            return $"[{DateTime.Now}]: {message}\r\n";
        }
    }
}
