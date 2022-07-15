using System;
using System.Linq;

namespace ConsoleApp4
{
    //Word Filter
    //Read an array of strings and take only words, whose length is an even number. Print each word on a new line.
    //Examples
    //Input
    //  kiwi orange banana apple
    //Output
    //  kiwi
    //  orange
    //  banana
    //
    //Input
    //  pizza cake pasta chips
    //Output
    //  cake

    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .Where(w => w.Length % 2 == 0)
                .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
