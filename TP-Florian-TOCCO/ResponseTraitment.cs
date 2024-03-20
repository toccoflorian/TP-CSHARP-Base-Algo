using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Florian_TOCCO
{
    internal static class ResponseTraitment
    {

        public static (bool, string) CheckStringResponse(string? str)          // enlever le double retour
        {
            if ( str == null || str.Length < 3) return (false, "");
            return (true, str);
        }

        public static bool CheckMarqueValidity(string str)
        {
            if (str.Any(char.IsDigit)) 
            {
                Display.DisplayErrorMessage();
                return false;
            }
            else return true;
        }
    }
}
