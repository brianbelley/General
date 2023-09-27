using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_2210662.VALIDATION
{
    public class Validator_User
    {
        public static bool Password_validation(string input)
        {

            if(input.Length < 8)
            {
                return false;
            }

            for(int i = 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(input, i)))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool UserId_validation(string input)
        {
            if(input.Length != 4)
            {
                return false;
            }

            for(int i =0 ; i < input.Length; i++)
            {
                if (!(char.IsDigit(input, i)))
                {
                    return false;
                }
            }
            return true;
        }        

        public static bool Qualified_jobid_validation(int input)
        {
            if(input != 11111 || input != 22222 || input != 33333 || input != 44444)
            {
                return false;
            }
            return true;
        }

        public static bool Employee_Name_validation(string input)
        {
            if(input.Length == 0)
            {
                return false;
            }

            for  (int i =0 ; i < input.Length; i++)
            {
                if(!char.IsLetter(input,i) && !char.IsWhiteSpace(input, i))
                {
                    return false;
                }

            }
            return true;
        }

        public static bool JobId_validation(string input)
        {
            if(input.Length != 5)
            {
                return false;
            }


            for (int i =0 ; i < input.Length; i++ )
            {
                if (!char.IsDigit(input, i))
                {
                    return false;
                }
            }


            return true;
        }

        public static bool JobId_valid(int input)
        {

            if(input != 11111 && input != 22222 && input != 33333 && input != 44444 && input != 55555)
            {
                return false;
            }

            return true;
        }

        public static bool Email_validation(string input)
        {
            if(input.Length == 0)
            {
                return false;
            }

            for(int i =0 ; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input, i))
                {
                    return false;
                }
            }

            return true;
        }




        public static bool Missing_input_validation(string input)
        {
            if(input.Length == 0)
            {
                return false;
            }



            return true;
        }

    }
}
