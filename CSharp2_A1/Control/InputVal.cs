using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    class InputVal
    {
        public static bool ValidateName(string name, out string errorMessage)
        {
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "String can not be empty";
                return false;
            }

            if (name.Length > 20)
            {
                errorMessage = "Name must be max 20 characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }
    }
}
