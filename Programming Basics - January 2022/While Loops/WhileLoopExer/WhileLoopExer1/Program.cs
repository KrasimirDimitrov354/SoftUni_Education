using System;

namespace WhileLoopExer1
{
    class Program
    {
        static void Main(string[] args)
        {
            string soughtBook = Console.ReadLine();
            int counter = 0;

            while (true)
            {
                string currentBook = Console.ReadLine();

                if (currentBook != "No More Books")
                {
                    counter++;

                    if (currentBook == soughtBook)
                    {
                        counter--;
                        Console.WriteLine($"You checked {counter} books and found it.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }
        }
    }
}
