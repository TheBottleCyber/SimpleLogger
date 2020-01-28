using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public interface IFormatter
    {
        string FormatMessage<T>(T message);
    }
}
