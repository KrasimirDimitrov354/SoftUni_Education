using System;
using System.Linq;

namespace ConsoleApp1
{
    //Valid Usernames
    //Create a program that reads user names on a single line (joined by ", ") and prints all valid usernames.
    //A valid username:
    //  •	Has length between 3 and 16 characters and
    //  •	Contains only letters, numbers, hyphens, and underscores
    //Examples
    //Input
    //  sh, too_long_username, !lleg @l ch @rs, jeffbutt
    //Output
    //  jeffbutt
    //
    //Input
    //  Jeff, john45, ab, cd, peter-ivanov, @smith
    //Output
    //  Jeff
    //  John45
    //  peter-ivanov

    class Program
    {
        static void Main()
        {
            string[] users = Console.ReadLine()
                .Split(", ")
                .Where(user => user.Length >= 3 && user.Length <= 16)
                .ToArray();

            for (int i = 0; i < users.Length; i++)
            {
                string currentUser = users[i];
                bool isValid = false;

                for (int j = 0; j < currentUser.Length; j++)
                {
                    char currentSymbol = currentUser[j];
                    bool isLetter = (currentSymbol >= 65 && currentSymbol <= 90) 
                        || (currentSymbol >= 97 && currentSymbol <= 122);

                    bool isNumber = currentSymbol >= 48 && currentSymbol <= 57;

                    bool isHyphenOrUnderscore = currentSymbol == '-' || currentSymbol == '_';

                    if (isLetter || isNumber || isHyphenOrUnderscore)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(currentUser);
                }
            }
        }
    }
}
