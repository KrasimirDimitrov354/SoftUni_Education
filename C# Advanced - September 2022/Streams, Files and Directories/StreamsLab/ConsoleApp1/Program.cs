using System.IO;

namespace OddLines
{
    //Odd Lines
    //Write a program that reads a text file (e.g. input.txt) and writes every odd line in another file. Line numbers start from 0.

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                using (writer)
                {
                    int lineCounter = 0;

                    while (!reader.EndOfStream)
                    {
                        string currentLine = reader.ReadLine();

                        if (lineCounter % 2 != 0)
                        {
                            writer.WriteLine(currentLine);
                        }

                        lineCounter++;
                    }
                }
            }
        }
    }
}

