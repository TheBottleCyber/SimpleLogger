using System;
using System.IO;
using System.Threading.Tasks;
using SimpleLogger.Types;

namespace SimpleLogger
{
    public class Logger
    {
        private LoggerSettings _loggerSettings { get; }
        public Logger(LoggerSettings loggerSettings) => _loggerSettings = loggerSettings;

        public async Task WriteConsoleAsync(string message)
        {
            await Console.Out.WriteAsync(FormatMessage(message));
        }

        public void WriteConsole(string message)
        {
            Console.Write(FormatMessage(message));
        }

        public async Task WriteFileAsync(string filePath, string message)
        {
            await File.AppendAllTextAsync(filePath, FormatMessage(message));
        }

        public void WriteFile(string filePath, string message)
        {
            File.AppendAllText(filePath, FormatMessage(message));
        }

        private string FormatMessage(string message)
        {
            if (_loggerSettings.EmptyNullException && string.IsNullOrEmpty(message)) throw new ArgumentException("Message cannot be empty", nameof(message));

            string buildedMessage = string.Empty;

            switch (_loggerSettings.DateFormatting)
            {
                case DateFormatting.Brackets:
                    {
                        buildedMessage += $"[{DateTime.Now}]: ";
                        break;
                    }
            }

            switch (_loggerSettings.MessageFormatting)
            {
                case MessageFormatting.None:
                    {
                        buildedMessage += $"{message}";
                        break;
                    }

                case MessageFormatting.Newline:
                    {
                        buildedMessage += $"{message}\r\n";
                        break;
                    }
            }

            return buildedMessage;
        }
    }
}
