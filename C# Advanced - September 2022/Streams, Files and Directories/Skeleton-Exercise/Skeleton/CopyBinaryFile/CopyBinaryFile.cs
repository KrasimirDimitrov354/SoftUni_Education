namespace CopyBinaryFile
{
    //Write a program that copies the contents of a binary file (e.g. copyMe.png) to another binary file (e.g. copyMe-copy.png) using FileStream.
    //You are not allowed to use the File class or similar helper classes.
    
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream streamInput = new FileStream(inputFilePath, FileMode.Open);
            FileStream streamOutput = new FileStream(outputFilePath, FileMode.Create);

            using (streamInput)
            {
                using (streamOutput)
                {
                    byte[] bufferInput = new byte[streamInput.Length];
                    streamInput.Read(bufferInput, 0, (int)streamInput.Length);

                    for (int i = 0; i < bufferInput.Length; i++)
                    {
                        streamOutput.WriteByte(bufferInput[i]);
                    }
                }
            }
        }
    }
}
