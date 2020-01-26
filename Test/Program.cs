using System.Threading.Tasks;
using SimpleLogger;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // ¯\_(ツ)_/¯

            var logger = new Logger(new LoggerSettings());
            logger.WriteConsole("Work!");
            await logger.WriteConsoleAsync("Async work!");

            logger.WriteFile("log", "File writing work!");
            await logger.WriteFileAsync("log", "File async writing work!");
        }
    }
}
