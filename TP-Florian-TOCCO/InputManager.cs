


namespace TP_Florian_TOCCO
{
    public static class InputManager
    {
        public static bool CheckStringValidity(string? str, int? maxLength = null, int? minLength = 2)
        {

            if (str == null || str.Length < minLength)
            {
                return false;
            }
            if (maxLength != null && str.Length > maxLength)
            {
                return false;
            }
            return true;
        }

        public static bool CheckMarqueValidity(string str) 
        {
            if (str.Any(char.IsDigit))
            {
                return false;
            }
            return true;
        }

        public static bool checkIntValidity(int integer, int? maxValue = null)
        {
            if(integer < 1 || (maxValue != null && integer > maxValue)) 
            {
                return false;
            }
            return true;
        }

        public static string GetStringResponse(string message)
        {
            Console.WriteLine("\n" + message);

            string? responseString = Console.ReadLine();

            if (!CheckStringValidity(responseString))
            {
                Display.DisplayWrongChoiceMessage();
                return GetStringResponse(message);
            }
            return responseString;
        }

        public static int GetIntResponse(string message, int? maxLength = null, int? minLength = 1, int? maxValue = null)
        {
            Console.WriteLine("\n"+ message);
            string? str = Console.ReadLine();
            if (!CheckStringValidity(str, maxLength, minLength))
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            if (!int.TryParse(str, out int result))
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            if (!checkIntValidity(result, maxValue))                   
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            
            return result;
        }

    }

    
}
