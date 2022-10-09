using System.IO;

namespace MergeFiles
{
    //Merge Files
    //Write a program that reads the contents of two input text files (e.g. input1.txt and input2.txt) and merges them line by line together into a third text file (e.g. output.txt).
    //The merging is done as follows:
    //  •	Line 1 from input1.txt
    //  •	Line 1 from input2.txt
    //  •	Line 2 from input1.txt
    //  •	Line 2 from input2.txt
    //  •	etc.
    //
    //If some of the files have more lines than the other, append at the end of the output the lines which cannot be matched with the other file.

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] linesFromFirst = File.ReadAllLines(firstInputFilePath);
            string[] linesFromSecond = File.ReadAllLines(secondInputFilePath);

            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                int linesToAppendFromBoth = 0;

                if (linesFromFirst.Length >= linesFromSecond.Length)
                {
                    linesToAppendFromBoth = linesFromSecond.Length;
                }
                else
                {
                    linesToAppendFromBoth = linesFromFirst.Length;
                }

                for (int i = 0; i < linesToAppendFromBoth; i++)
                {
                    writer.WriteLine(linesFromFirst[i]);
                    writer.WriteLine(linesFromSecond[i]);
                }

                if (linesFromFirst.Length - linesToAppendFromBoth > 0)
                {
                    for (int i = linesToAppendFromBoth; i < linesFromFirst.Length; i++)
                    {
                        writer.WriteLine(linesFromFirst[i]);
                    }
                }
                else if (linesFromSecond.Length - linesToAppendFromBoth > 0)
                {
                    for (int i = linesToAppendFromBoth; i < linesFromSecond.Length; i++)
                    {
                        writer.WriteLine(linesFromSecond[i]);
                    }
                }
            }
        }
    }
}
