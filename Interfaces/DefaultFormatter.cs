using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Interfaces
{
    public class DefaultFormatter : IFormatter
    {
        public string FormatMessage(string message)
        {
            return $"[{DateTime.Now}]: {message}\r\n";
        }

        public string FormatMessage(Exception exception)
        {
            return exception.ToString();
        }
    }
}
