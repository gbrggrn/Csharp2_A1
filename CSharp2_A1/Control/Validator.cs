using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    class Validator
    {
        private static List<string>? errorMessages = new List<string>();
        private static readonly string success = "Success";

        public static List<string> GetErrorMessages()
        {
            List<string> errorMessagesToReturn = new List<string>(errorMessages!);
            ClearErrorMessages();
            return errorMessagesToReturn;
        }

        internal static void ClearErrorMessages()
        {
            errorMessages!.Clear();
        }

        public static bool EmptyOrNot(string input)
        {
            if (string.IsNullOrEmpty(input)) 
            {
                return false;
            }

            return true;
        }

        public static bool DoubleOrNot(string input)
        {
            if (double.TryParse(input, out double result))
            {
                return true;
            }

            return false;
        }

        public static bool IntOrNot(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return true;
            }

            return false;
        }
    }
}
