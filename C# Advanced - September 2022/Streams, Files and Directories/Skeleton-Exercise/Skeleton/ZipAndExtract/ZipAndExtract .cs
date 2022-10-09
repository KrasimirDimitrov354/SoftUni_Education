namespace ZipAndExtract
{
    //Zip and Extract
    //Write a program that creates a ZIP file holding a given input file, and then extracts the ZIP file from the archive into a separate output file.
    //  •	Use the copyMe.png file from your resources as input and zip it into a ZIP file of your choice, e.g. archive.zip.
    //  •	Extract the file from the archive into a new file of your choice, e.g. extracted.png.
    //
    //If your code works correctly, the input and output files should be the same.

    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            //FileStream streamInput = new FileStream(inputFilePath, FileMode.Open);
            //FileInfo file = new FileInfo(inputFilePath);            

            //using (streamInput)
            //{
            //byte[] bufferInput = new byte[streamInput.Length];
            //streamInput.Read(bufferInput, 0, (int)streamInput.Length);

            ZipArchive archiveInput = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);

            using (archiveInput)
            {
                string fileName = Path.GetFileName(inputFilePath);
                archiveInput.CreateEntryFromFile(inputFilePath, fileName);

                //var archiveEntry = archiveInput.CreateEntry(file.Name);
                //var archiveStream = archiveEntry.Open();

                //using (archiveStream)
                //{
                //archiveStream.Write(bufferInput, 0, bufferInput.Length);
                //}
            }
        }
    //}


        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            ZipArchive archiveOuput = ZipFile.OpenRead(zipArchiveFilePath);

            using (archiveOuput)
            {
                var archiveEntry = archiveOuput.GetEntry(fileName);
                archiveEntry.ExtractToFile(outputFilePath);
            }
        }
    }
}
