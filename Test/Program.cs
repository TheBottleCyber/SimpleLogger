﻿using System;
using System.Threading.Tasks;
using SimpleLogger;
using SimpleLogger.Interfaces;

namespace Test
{
    class Program
    {
        class OwnImplementation : IFormatter
        {
            public string FormatMessage(string message)
            {
                return $"{message}";
            }

            public string FormatMessage(Exception ex)
            {
                return ex.ToString();
            }
        }

        static async Task Main(string[] args)
        {
            // ¯\_(ツ)_/¯

            var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
            logger.Write(WriteType.Console,"Work!");
            await logger.WriteAsync(WriteType.Console, "Async work!");

            logger.Write(WriteType.File, "File writing work!", "log");
            await logger.WriteAsync(WriteType.File, "File writing work!", "log");

            var loggerOwnImplementation = new Logger(new LoggerSettings(new OwnImplementation()));
            loggerOwnImplementation.Write(WriteType.Console, "Own implementation Work!");
        }
    }
}