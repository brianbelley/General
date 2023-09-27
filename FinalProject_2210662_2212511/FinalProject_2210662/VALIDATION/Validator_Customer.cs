using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject_2210662.VALIDATION
{
    public class Validator_Customer: Validator_User
    {
        public static bool CustomerId_validation(string input)
        {
            if (input.Length != 6)
            {
                return false;
            }

            for (int i =0 ; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
                
            }
            return true;
        }


        public static bool Name_validation(string input)
        {
            if (input.Length == 0) 
            { 
            return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(input,i) || char.IsWhiteSpace(input,i)))
                {
                    return false;
                }

            }
            return true;

        }

        public static bool Status_Validation(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }

            for(int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit((char)input[i]))
                {
                    return false;
                }
            }
            return true;

        }

        public static bool PostalCode_validation(string input)
        {
            Regex regex = new Regex(@"(?:[A-Z]\d[A-Z][ -]?\d[A-Z]\d)$");

            if(!regex.IsMatch(input))
            {
                return false;
            }

            return true;


        }


    }
}
