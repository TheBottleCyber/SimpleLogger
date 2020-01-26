¯\\_(ツ)_/¯

# What is it?
Simple library for logging your messages/exceptions with support for your formatting

# Version Support
.NET Standart 2.1 / .NET Core 3.0

# Quick start
```c#
var logger = new Logger(new LoggerSettings(new DefaultFormatter()));
logger.Write(WriteType.Console, "Work!");
```

# Own Implementation ?
The work is done via the IFormatter interface, inherit it as shown in Test project
