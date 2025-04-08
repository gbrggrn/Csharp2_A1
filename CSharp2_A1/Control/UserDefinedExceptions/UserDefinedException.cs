using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control.UserDefinedExceptions
{
    public class UserDefinedException : Exception
    {
        public UserDefinedException() { }

        public UserDefinedException(string message) : base(message) { }

        public UserDefinedException(string message, Exception inner) : base(message, inner) { }

        public UserDefinedException(string message, string moreInfo) : base(message)
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
