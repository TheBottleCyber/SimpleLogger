using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public enum WriteType
    {
        Console,
        File,
        DebugOutput
    }

    public class Logger
    {
        private LoggerSettings _loggerSettings { get; }
        public Logger(LoggerSettings loggerSettings) => _loggerSettings = loggerSettings;

        /// <summary>
        /// Logger Write
        /// </summary>
        /// <param name="type">Specifying where to write the message</param>
        /// <param name="message">The message you want to write</param>
        /// <param name="filePath">This field is only needed for WriteType.File, specifying file</param>
        public void Write(WriteType type, string message, string filePath = "")
        {
            switch (type)
            {
                case WriteType.Console:
                {
                    Console.Write(_loggerSettings.Formatter.FormatMessage(message));
                    break;
                }

                case WriteType.File:
                {
                    File.WriteAllText(filePath, _loggerSettings.Formatter.FormatMessage(message));
                    break;
                }

                case WriteType.DebugOutput:
                {
                    Debug.WriteLine(_loggerSettings.Formatter.FormatMessage(message));
                    break;
                }
            }
        }

        /// <summary>
        /// Logger Write Async
        /// </summary>
        /// <param name="type">Specifying where to write the message</param>
        /// <param name="message">The message you want to write</param>
        /// <param name="filePath">This field is only needed for WriteType.File, specifying file</param>
        public async Task WriteAsync(WriteType type, string message, string filePath = "")
        {
            switch (type)
            {
                case WriteType.Console:
                {
                    await Console.Out.WriteAsync(_loggerSettings.Formatter.FormatMessage(message));
                    break;
                }

                case WriteType.File:
                {
                    await File.WriteAllTextAsync(filePath, _loggerSettings.Formatter.FormatMessage(message));
                    break;
                }

                case WriteType.DebugOutput:
                {
                    Debug.WriteLine(_loggerSettings.Formatter.FormatMessage(message));
                    break;
                }
            }
        }
    }
}
