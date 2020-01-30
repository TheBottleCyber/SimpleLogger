using SimpleLogger.Formatters;

namespace SimpleLogger
{
    public class LoggerSettings
    {
        public IFormatter Formatter { get; }
        public bool EmptyNullException { get; }

        /// <summary>
        /// Initialize settings for Logger
        /// </summary>
        /// <param name="formatter">Formatter interface, default implements DefaultFormatter</param>
        /// <param name="emptyNullException">Throw Exception if message null</param>
        public LoggerSettings(IFormatter formatter = null, bool emptyNullException = false)
        {
            Formatter = formatter ?? new DefaultFormatter();
            EmptyNullException = emptyNullException;
        }
    }
}
