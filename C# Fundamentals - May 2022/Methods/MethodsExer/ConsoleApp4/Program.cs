using System;

namespace ConsoleApp4
{
    class Program
    {
        //Password Validator
        //Create a program that checks if a given password is valid.
        //The password validation rules are:
        //  •	It should contain 6 – 10 characters (inclusive)
        //  •	It should contain only letters and digits
        //  •	It should contain at least 2 digits
        //If it is not valid, for any unfulfilled rule print the corresponding message:
        //  •	"Password must be between 6 and 10 characters"
        //  •	"Password must consist only of letters and digits"
        //  •	"Password must have at least 2 digits"
        //Examples
        //Input         Output
        //logIn         Password must be between 6 and 10 characters
        //              Password must have at least 2 digits
        //Input         Output
        //MyPass123     Password is valid
        //Input         Output
        //Pa$s$s        Password must consist only of letters and digits
        //              Password must have at least 2 digits

        private static bool CheckLength(string input)
        {
            bool isValid = false;

            if (input.Length >= 6 && input.Length <= 10)
            {
                isValid = true;
            }

            return isValid;
        }

        private static bool CheckComposition(string input)
        {
            bool isValid = false;

            for (int i = 0; i < input.Length; i++)
            {
                bool isDigit = (int)input[i] >= 48 && (int)input[i] <= 57;
                bool isUppercase = (int)input[i] >= 65 && (int)input[i] <= 90;
                bool isLowercase = (int)input[i] >= 97 && (int)input[i] <= 122;

                if (isDigit == false && isUppercase == false && isLowercase == false)
                {                    
                    break;
                }
                else if (i == input.Length - 1)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private static bool CheckDigits(string input)
        {
            bool isValid = false;
            byte counterDigits = 0;

            for (int i = 0; i < input.Length; i++)
            {
                bool isDigit = int.TryParse(input[i].ToString(), out int digit);

                if (isDigit)
                {
                    counterDigits++;
                }               
            }

            if (counterDigits >= 2)
            {
                isValid = true;
            }

            return isValid;
        }

        private static void ValidatePassword(string input)
        {
            if (CheckLength(input) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (CheckComposition(input) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (CheckDigits(input) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (CheckLength(input) && CheckComposition(input) && CheckDigits(input))
            {
                Console.WriteLine("Password is valid");
            }
        }


        static void Main()
        {
            string password = Console.ReadLine();
            ValidatePassword(password);
        }
    }
}
