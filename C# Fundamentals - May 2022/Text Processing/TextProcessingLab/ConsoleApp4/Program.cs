using System;
using System.Linq;

namespace ConsoleApp4
{
    //Text Filter
    //Create a program that takes a text and a string of banned words. All words included in the ban list should be replaced with asterisks "*", equal to the word's length.
    //The entries in the ban list will be separated by a comma and space - ", ". The ban list should be entered on the first input line and the text on the second input line. 
    //Examples
    //Input
    //  Linux, Windows
    //  It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux!
    //  Sincerely, a Windows client
    //Output
    //  It is not *****, it is GNU/*****. ***** is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/*****!
    //  Sincerely, a ******* client
    //
    //Input
    //  von Richthofen, German, 80 air
    //  Manfred Albrecht Freiherr von Richthofen, known in English as Baron von Richthofen was a fighter pilot with the German Air Force during World War I.
    //  He is considered the ace-of-aces of the war, being officially credited with 80 air combat victories.
    //Output
    //  Manfred Albrecht Freiherr **************, known in English as Baron ************** was a fighter pilot with the ****** Air Force during World War I.
    //  He is considered the ace-of-aces of the war, being officially credited with ****** combat victories.

    class Program
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string currentWord = bannedWords[i];

                while (text.Contains(currentWord))
                {
                    text = text.Replace(currentWord, new string('*', currentWord.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
