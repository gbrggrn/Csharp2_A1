using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.UserDefinedExceptions
{
    public class SerializationException : Exception
    {
        public SerializationException() { }

        public SerializationException(string message) : base(message) { }

        public SerializationException(string message, Exception inner) : base(message, inner) { }

        public SerializationException(string message, string moreInfo) : base(message)
        {
            MoreInfo = moreInfo;
        }

        public string MoreInfo { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, More information: {MoreInfo}";
        }
    }
}
