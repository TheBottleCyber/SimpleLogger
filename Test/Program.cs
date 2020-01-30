using System;
using System.Threading.Tasks;
using SimpleLogger;
using SimpleLogger.Formatters;

namespace Example
{
    class Program
    {
        class OwnImplementation : IFormatter
        {
            public string FormatMessage<T>(T message)
            {
                if(message is string) return $"~{message}~\r\n";
                // ...

                return "not string\r\n";
            }
        }

        static async Task Main(string[] args)
        {
            // ¯\_(ツ)_/¯
            var logger = new Logger();
            logger.Write(LoggerOutputType.Console, "Work!");
            logger.Write(LoggerOutputType.Console, GetTestException());
            await logger.WriteAsync(LoggerOutputType.Console, "Async work!");

            logger.Write(LoggerOutputType.File, "File writing work!", "log");
            await logger.WriteAsync(LoggerOutputType.File, "File writing work!", "log");

            var jsonLogger = new Logger(new LoggerSettings(new JSONFormatter()));
            jsonLogger.Write(LoggerOutputType.Console, GetTestException());

            var loggerOwnImplementation = new Logger(new LoggerSettings(new OwnImplementation()));
            loggerOwnImplementation.Write(LoggerOutputType.Console, "Own implementation Work!");
            loggerOwnImplementation.Write(LoggerOutputType.Console, GetTestException()); // Writes no string

            var formatted = loggerOwnImplementation.FormatMessage("Formating via own implementation work!");
            Console.WriteLine(formatted);
        }

        static Exception GetTestException()
        {
            try
            {
                // I couldn't think of anything better and copied it from Google =/
                var ints = new[] {1, 2, 3};
                var s = ints[3];

                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
