using System;

namespace NestedLoopExer3
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrime = 0;
            int sumNonPrime = 0;

            bool isPrime = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }
                else
                {
                    int num = int.Parse(input);

                    if (num < 0)
                    {
                        Console.WriteLine("Number is negative.");
                    }
                    else if (num == 0 || num == 1 || num == 2 || num == 3 || num == 5 || num == 7)
                    {
                        sumPrime += num;
                    }
                    else
                    {
                        for (int i = 2; i <= 9; i++)
                        {
                            if (num % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }

                        if (isPrime)
                        {
                            sumPrime += num;
                        }
                        else
                        {
                            sumNonPrime += num;
                            isPrime = true;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
