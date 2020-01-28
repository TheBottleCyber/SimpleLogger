using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SimpleLogger
{
    class SerializationMessage<T>
    {
        public string DateTime { get; }    
        public T Message { get; }

        public SerializationMessage(T message)
        {
            DateTime = System.DateTime.Now.ToString(CultureInfo.CurrentCulture);
            Message = message;
        }
    }
}
