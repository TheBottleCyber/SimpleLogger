¯\\_(ツ)_/¯

# What is it?
Simple library for logging your messages/exceptions/etc with support for your formatting

# Version Support
.NET Standart 2.1 / .NET Core 3.0

# Quick start
```c#
var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
logger.Write(LoggerOutputType.Console, "Work!");
```

# Format Message using Library
```c#
var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
var formatted = logger.FormatMessage("Work!");
```

# Own Implementation ?
The work is done via the IFormatter interface from SimpleLogger namespace, inherit it as shown in Test project