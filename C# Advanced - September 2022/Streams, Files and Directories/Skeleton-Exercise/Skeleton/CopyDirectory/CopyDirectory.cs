namespace CopyDirectory
{
    //Copy Directory
    //Write a method which copies a directory with files (without its subdirectories) to another directory.
    //The input folder and the output folder should be given as parameters from the console.
    //
    //If the output folder already exists, first delete it together with all its content.

    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                DirectoryInfo existingDirectory = new DirectoryInfo(outputPath);

                foreach (FileInfo existingFile in existingDirectory.GetFiles())
                {
                    existingFile.Delete();
                }

                foreach (DirectoryInfo dir in existingDirectory.GetDirectories())
                {
                    dir.Delete();
                }
            }

            Directory.CreateDirectory(outputPath);
            DirectoryInfo inputDirectory = new DirectoryInfo(inputPath);
            FileInfo[] inputFiles = inputDirectory.GetFiles();

            foreach (FileInfo file in inputFiles)
            {
                string destinationFile = Path.Combine(outputPath, file.Name);

                File.Copy(file.FullName, destinationFile);
            }
        }
    }
}
