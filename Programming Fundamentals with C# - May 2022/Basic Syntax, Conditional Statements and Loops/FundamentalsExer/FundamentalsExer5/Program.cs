using System;

namespace FundamentalsExer5
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            int counterTries = 0;
            int counterIdenticalSymbols = 1;
            bool passwordFound = false;

            while (counterTries < 4)
            {
                if (passwordFound)
                {                   
                    break;
                }
                else
                {
                    counterTries++;

                    string password = Console.ReadLine();

                    if (password.Length != username.Length)
                    {
                        if (counterTries < 4)
                        {
                            Console.WriteLine("Incorrect password. Try again.");
                        }
                        else
                        {
                            Console.WriteLine($"User {username} blocked!");
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= password.Length; i++)
                        {
                            char usernameSymbol = username[i - 1];
                            char passwordSymbol = password[password.Length - i];
                            bool symbolIsIdentical = (int)usernameSymbol == (int)passwordSymbol;

                            if (symbolIsIdentical == false)
                            {
                                if (counterTries < 4)
                                {
                                    Console.WriteLine("Incorrect password. Try again.");
                                }
                                else
                                {
                                    Console.WriteLine($"User {username} blocked!");
                                }
                                
                                counterIdenticalSymbols = 0;
                                break;
                            }
                            else
                            {
                                counterIdenticalSymbols++;

                                if (counterIdenticalSymbols == username.Length)
                                {                                   
                                    passwordFound = true;
                                }
                            }
                        }
                    }
                }                             
            }

            if (passwordFound)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}