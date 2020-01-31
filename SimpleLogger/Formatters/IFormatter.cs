namespace SimpleLogger
{
    public interface IFormatter
    {
        string FormatMessage<T>(T message);
    }
}
