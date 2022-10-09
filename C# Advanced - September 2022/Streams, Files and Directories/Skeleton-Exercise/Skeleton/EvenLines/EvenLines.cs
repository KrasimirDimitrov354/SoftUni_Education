namespace EvenLines
{
    //Even Lines
    //Write a program that reads a text file (e.g. text.txt) and prints on the console its even lines. Line numbers start from 0. Use StreamReader.
    //Before you print the result, replace {'-', ', ', '. ', '! ', '? '} with '@' and reverse the order of the words.

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader stream = new StreamReader(inputFilePath);
            StringBuilder result = new StringBuilder();

            using (stream)
            {
                int counter = 0;

                string pattern = @"[-,.!?]+";
                Regex regex = new Regex(pattern);

                while (!stream.EndOfStream)
                {
                    string[] wordsOnLine = stream.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (counter % 2 == 0)
                    {
                        wordsOnLine = wordsOnLine.Reverse().ToArray();

                        for (int i = 0; i < wordsOnLine.Length; i++)
                        {
                            wordsOnLine[i] = regex.Replace(wordsOnLine[i], "@");
                        }

                        result.AppendLine(String.Join(" ", wordsOnLine));
                    }

                    counter++;
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
