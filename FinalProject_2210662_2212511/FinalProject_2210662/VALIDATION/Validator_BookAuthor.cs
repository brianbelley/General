using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace FinalProject_2210662.VALIDATION
{
    public class Validator_BookAuthor:Validator_Customer
    {

        public static bool null_validation(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            return true;
        }

        public static bool int_validation(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool char_validation(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool decimal_validation(string input)
        {
            Regex regex = new Regex(@"^([0-9]{1,5})([.,][0-9]{1,2})?$");

            if (!regex.IsMatch(input))
            {
                return false;
            }

            return true;


        }

        public static bool year_validation(string input)
        {
            int year = DateTime.Now.Year;

            if (input.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input, i))
                {
                    return false;
                }
            }

            if (Convert.ToInt32(input) > year)
            {
                return false;
            }

            return true;

        }



    }
}
