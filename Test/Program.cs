using System;
using System.Threading.Tasks;
using SimpleLogger;
using SimpleLogger.Interfaces;

namespace Test
{
    class Program
    {
        class OwnImplementation : IFormatter
        {
            public string FormatMessage<T>(T message)
            {
                if(message is string) return $"~{message}~";
                // ...

                return "not string\r\n";
            }
        }

        static async Task Main(string[] args)
        {
            // ¯\_(ツ)_/¯

            var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
            logger.Write(LoggerOutputType.Console, "Work!");
            await logger.WriteAsync(LoggerOutputType.Console, "Async work!");

            logger.Write(LoggerOutputType.File, "File writing work!", "log");
            await logger.WriteAsync(LoggerOutputType.File, "File writing work!", "log");

            var loggerOwnImplementation = new Logger(new LoggerSettings(new OwnImplementation()));
            loggerOwnImplementation.Write(LoggerOutputType.Console, "Own implementation Work!");
            loggerOwnImplementation.Write(LoggerOutputType.Console, 1); // Writes no string

            var formatted = loggerOwnImplementation.FormatMessage("Formating via own implementation work!");
            Console.WriteLine(formatted);
        }
    }
}
