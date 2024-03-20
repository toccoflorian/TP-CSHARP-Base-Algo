

namespace TP_Florian_TOCCO
{
    internal static class ResponseRequest
    {

        public static string GetStringResponse(string message)
        {
            Console.WriteLine("\n" + message);
            (bool res, string str) = ResponseTraitment.CheckStringResponse(Console.ReadLine());         // enlever le double retour
            if (!res)
            {
                Display.DisplayWrongChoiceMessage();
                return GetStringResponse(message);
            }
            return str;
        }

        public static int GetIntResponse(string message, int? maxLength = null, int? minLength = 1, int? maxValue = null)
        {
            Console.WriteLine("\n"+ message);
            string? str = Console.ReadLine();
            if (str == null || str.Length > maxLength || str.Length < minLength)
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            if (!int.TryParse(str, out int result))
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            if (result < 1)                   
            {
                Display.DisplayWrongChoiceMessage();
                return GetIntResponse(message, maxLength, minLength);
            }
            if (maxValue != null) if (result > maxValue)
                {
                    Display.DisplayWrongChoiceMessage();
                    return GetIntResponse(message, maxLength, minLength, maxValue);
                }
            return result;
        }

    }

    
}
