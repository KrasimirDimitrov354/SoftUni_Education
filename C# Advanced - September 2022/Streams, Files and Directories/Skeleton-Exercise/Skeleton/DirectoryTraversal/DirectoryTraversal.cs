namespace DirectoryTraversal
{
    //Directory Traversal
    //Write a program that traverses a given directory for all files with the given extension. Search through the first level of the directory only.
    //
    //Write information about each found file in a text file named report.txt and save it on the Desktop. Ensure the desktop path is always valid regardless of the user.
    //
    //The files should be grouped by their extension. Extensions should be ordered by the count of their files descending, then by name alphabetically.
    //Files under an extension should be ordered by their size. 

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = directory.GetFiles();
            
            Dictionary<string, List<FileData>> filesByExtension = new Dictionary<string, List<FileData>>();

            foreach (FileInfo file in files)
            {
                string extension = file.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new List<FileData>());
                }

                filesByExtension[extension].Add( new FileData(file.Name, file.Length));
            }

            filesByExtension = filesByExtension
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(f => f.Key, f => f.Value);

            return CreateReport(filesByExtension);
        }

        public static string CreateReport(Dictionary<string, List<FileData>> filesByExtension)
        {
            StringBuilder report = new StringBuilder();

            foreach (var extension in filesByExtension)
            {
                List<FileData> orderedFiles = extension.Value
                    .OrderBy(f => f.FileSize)
                    .ToList();

                report.AppendLine(extension.Key);

                for (int i = 0; i < orderedFiles.Count; i++)
                {
                    FileData currentFile = orderedFiles[i];

                    report.AppendLine($"--{currentFile.FileName} - {Math.Round(currentFile.FileSize / 1024, 3).ToString("G29")}kb");
                }
            }

            return report.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            using (fileStream)
            {
                byte[] fileText = Encoding.UTF8.GetBytes(textContent);
                fileStream.Write(fileText, 0, fileText.Length);
            }
        }
    }

    public class FileData
    {
        public FileData(string fileName, decimal fileSize)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
        }

        public string FileName { get; set; }
        public decimal FileSize { get; set; }
    }
}
