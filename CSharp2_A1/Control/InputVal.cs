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
                errorMessage = "Name can not be empty";
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

        public static bool ValidateHabitat(string habitat, out string errorMessage)
        {
            if (string.IsNullOrEmpty (habitat))
            {
                errorMessage = "Habitat can not be empty";
                return false;
            }

            if (habitat.Length > 20)
            {
                errorMessage = "Habitat must be max 20 characters";
                return false;
            }

            errorMessage = "Success";
            return true;
        }

        public static bool ValidateNumberOfLegs(string numberOfLegs, out string errorMessage)
        {
            if (!int.TryParse(numberOfLegs, out int legs))
            {
                errorMessage = "Number of legs has to be a number";
                return false;
            }
            else
            {
                if (legs < 0 || legs > 8)
                {
                    errorMessage = "Number of legs must be between 0-8";
                    return false;
                }
            }

            errorMessage = "Success";
            return true;
        }

        public static bool ValidateWingspan(string wingspan, out string errorMessage)
        {
            if (!double.TryParse(wingspan, out double span))
            {
                errorMessage = "Wingspan has to be given in cm";
                return false;
            }
            else
            {
                if (span < 0 || span > 300)
                {
                    errorMessage = "Wingspan must be between 0-300cm";
                    return false;
                }
            }

            errorMessage = "Success";
            return true;
        }

        public static bool ValidateLength(string length, out string errorMessage)
        {
            if (!double.TryParse(length, out double intLength))
            {
                errorMessage = "Length has to be a number";
                return false;
            }
            else
            {
                if (intLength < 0 || intLength > 600)
                {
                    errorMessage = "Length has to be between 0-600cm";
                    return false;
                }
            }

            errorMessage = "Success";
            return true;
        }
    }
}
