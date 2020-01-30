using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public enum LoggerOutputType
    {
        Console,
        File,
        DebugOutput
    }

    public class Logger
    {
        private LoggerSettings _loggerSettings { get; }
        public Logger(LoggerSettings loggerSettings = null) => _loggerSettings = loggerSettings ?? new LoggerSettings();

        /// <summary>
        /// Logger Write
        /// </summary>
        /// <param name="loggerOutputType">Specifying where to write the message</param>
        /// <param name="message">The message you want to write</param>
        /// <param name="filePath">This field is only needed for LoggerOutputType.File, specifying file</param>
        public void Write<T>(LoggerOutputType loggerOutputType, T message, string filePath = "")
        {
            switch (loggerOutputType)
            {
                case LoggerOutputType.Console:
                {
                    Console.Write(FormatMessage(message));
                    break;
                }

                case LoggerOutputType.File:
                {
                    File.WriteAllText(filePath, FormatMessage(message));
                    break;
                }

                case LoggerOutputType.DebugOutput:
                {
                    Debug.WriteLine(FormatMessage(message));
                    break;
                }
            }
        }

        /// <summary>
        /// Logger Write Async
        /// </summary>
        /// <param name="loggerOutputType">Specifying where to write the message</param>
        /// <param name="message">The message you want to write</param>
        /// <param name="filePath">This field is only needed for LoggerOutputType.File, specifying file</param>
        public async Task WriteAsync<T>(LoggerOutputType loggerOutputType, T message, string filePath = "")
        {
            switch (loggerOutputType)
            {
                case LoggerOutputType.Console:
                {
                    await Console.Out.WriteAsync(FormatMessage(message));
                    break;
                }

                case LoggerOutputType.File:
                {
                    await File.WriteAllTextAsync(filePath, FormatMessage(message));
                    break;
                }

                case LoggerOutputType.DebugOutput:
                {
                    Debug.WriteLine(FormatMessage(message));
                    break;
                }
            }
        }

        /// <summary>
        /// Logger Message Formatter
        /// </summary>
        /// <param name="message">The message you want to format</param>
        public string FormatMessage<T>(T message)
        {
            if (_loggerSettings.EmptyNullException && message == null) throw new ArgumentException("Message cannot be null", nameof(message));
            return _loggerSettings.Formatter.FormatMessage(message);
        }
    }
}
