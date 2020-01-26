using SimpleLogger.Types;

namespace SimpleLogger
{
    public class LoggerSettings
    {
        public MessageFormatting MessageFormatting { get; }
        public DateFormatting DateFormatting { get; }
        public bool EmptyNullException { get; }

        /// <summary>
        /// Initialize settings for Logger
        /// </summary>
        /// <param name="messageFormatting">Message Formatting argument, default set to append new line</param>
        /// <param name="dateFormatting">Date Formatting argument, default set to [01.01.1970 00:00:00]: </param>
        /// <param name="emptyNullException">Throw Exception if message null</param>
        public LoggerSettings(MessageFormatting messageFormatting = MessageFormatting.Newline, DateFormatting dateFormatting = DateFormatting.Brackets, bool emptyNullException = false)
        {
            MessageFormatting = messageFormatting;
            DateFormatting = dateFormatting;
            EmptyNullException = emptyNullException;
        }
    }
}
