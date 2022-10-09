using System.IO;

namespace LineNumbers
{
    //Line Numbers
    //Write a program that reads a text file (e.g. input.txt) and inserts line numbers in front of each of its lines.
    //The result should be written to another text file (e.g. output.txt).

    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                string[] lines = File.ReadAllLines(inputFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    writer.WriteLine($"{i + 1}. {lines[i]}");
                }
            }
        }
    }
}

