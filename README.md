¯\\_(ツ)_/¯

# What is it?
Simple library for logging your messages/exceptions/etc with JSON support and your own formatting implementations
Newtonsoft.Json included as external dependency

# Version Support
.NET Standart 2.1 / .NET Core 3.0
You can compile it as .NET Framework but more async methods not implemented in framework

# Quick start
```c#
var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
logger.Write(LoggerOutputType.Console, "Work!");
```

# JSON Message Formatting
```c#
var jsonLogger = new Logger(new LoggerSettings(new JSONFormatter()));
jsonLogger.Write(LoggerOutputType.Console, "Any message or exception");
```

# Format Message using Library
```c#
var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
var formatted = logger.FormatMessage("Work!");
```

# Own Implementation ?
The work is done via the IFormatter interface from SimpleLogger namespace, inherit it as shown in Example project