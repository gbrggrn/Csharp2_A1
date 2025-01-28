using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_A1.Control
{
    class InputVal
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

        public static bool ValidateAge(string age, out string errorMessage)
        {
            if (!int.TryParse(age, out int intAge))
            {
                errorMessage = "Age must be a number";
                errorMessages!.Add(errorMessage);
                return false;
            }

            if (intAge < 0 || intAge > 120)
            {
                errorMessage = "Age must be between 0-120";
                errorMessages!.Add(errorMessage);
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateName(string name, out string errorMessage)
        {
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Name can not be empty";
                errorMessages!.Add(errorMessage);
                return false;
            }

            if (name.Length > 20)
            {
                errorMessage = "Name must be max 20 characters";
                errorMessages!.Add(errorMessage);
                return false;
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateHabitat(string habitat, out string errorMessage)
        {
            if (string.IsNullOrEmpty (habitat))
            {
                errorMessage = "Habitat can not be empty";
                errorMessages!.Add(errorMessage);
                return false;
            }

            if (habitat.Length > 20)
            {
                errorMessage = "Habitat must be max 20 characters";
                errorMessages!.Add(errorMessage);
                return false;
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateNumberOfLegs(string numberOfLegs, out string errorMessage)
        {
            if (!int.TryParse(numberOfLegs, out int legs))
            {
                errorMessage = "Number of legs has to be a number";
                errorMessages!.Add(errorMessage);
                return false;
            }
            else
            {
                if (legs < 0 || legs > 8)
                {
                    errorMessage = "Number of legs must be between 0-8";
                    errorMessages!.Add(errorMessage);
                    return false;
                }
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateWingspan(string wingspan, out string errorMessage)
        {
            if (!double.TryParse(wingspan, out double span))
            {
                errorMessage = "Wingspan has to be given in cm";
                errorMessages!.Add(errorMessage);
                return false;
            }
            else
            {
                if (span < 0 || span > 300)
                {
                    errorMessage = "Wingspan must be between 0-300cm";
                    errorMessages!.Add(errorMessage);
                    return false;
                }
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateLength(string length, out string errorMessage)
        {
            if (!double.TryParse(length, out double intLength))
            {
                errorMessage = "Length has to be a number";
                errorMessages!.Add(errorMessage);
                return false;
            }
            else
            {
                if (intLength < 0 || intLength > 600)
                {
                    errorMessage = "Length has to be between 0-600cm";
                    errorMessages!.Add(errorMessage);
                    return false;
                }
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateBirdType(string birdType, List<string> types, out string errorMessage)
        {
            if (!string.IsNullOrEmpty(birdType))
            {
                errorMessage = "Bird type can not be empty";
                errorMessages!.Add(errorMessage);
                return false;
            }
            else
            {
                if (!types.Contains(birdType))
                {
                    errorMessage = $"Dove type has to be '{types[0]}' or '{types[1]}'";
                    errorMessages!.Add(errorMessage);
                    return false;
                }
            }

            errorMessage = success;
            return true;
        }

        public static bool ValidateAvgAirSpeed(string avgAirSpeed, out string errorMessage)
        {
            if (!string.IsNullOrEmpty(avgAirSpeed))
            {
                errorMessage = "Avg airspeed can not be empty";
                errorMessages!.Add(errorMessage);
                return false;
            }
            else
            {
                if (!double.TryParse(avgAirSpeed, out double intAverageAirSpeed))
                {
                    errorMessage = "Avg airspeed has to be a number";
                    errorMessages!.Add(errorMessage);
                    return false;
                }

                if (intAverageAirSpeed < 0 || intAverageAirSpeed > 500)
                {
                    errorMessage = "Airspeed can not exceed 500km/h";
                    errorMessages!.Add(errorMessage);
                    return false;
                }
            }

            errorMessage = success;
            return true;
        }
    }
}
