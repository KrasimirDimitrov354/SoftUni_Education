namespace LineNumbers
{
    //Line Numbers
    //Write a program that reads a text file (e.g. text.txt) and inserts line numbers in front of each of its lines.
    //It must also count all the letters and punctuation marks on each line, then insert both counts at the end of the lines. 
    //The result should be written to another text file (e.g. output.txt). Use the static class File to read and write all the lines of the input and output files.

    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            string patternLetters = @"[a-zA-z]";
            string patternPunctuation = @"[-.?!,'()]";

            Regex regexLetters = new Regex(patternLetters);
            Regex regexPunc = new Regex(patternPunctuation);

            for (int i = 0; i < lines.Length; i++)
            {
                string newLine = $"Line {i + 1}: {lines[i]} ({regexLetters.Matches(lines[i]).Count})({regexPunc.Matches(lines[i]).Count})";
                lines[i] = newLine;
            }

            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
