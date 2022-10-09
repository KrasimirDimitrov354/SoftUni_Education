using System.IO;

namespace ExtractBytes
{
    //Extract Special Bytes
    //You are given an image file (e.g. example.png) and a text file (e.g. bytes.txt), holding a list of bytes in the range [0…255].
    //Write a program to extract occurrences of all given bytes from the input file to an output binary file (e.g. output.bin).

    public class ExtractBytes
    {
        static void Main()
        {
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string imageFilePath = @"..\..\..\Files\example.png";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(bytesFilePath, imageFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string bytesFilePath, string imageFilePath, string outputPath)
        {
            FileStream streamBytes = new FileStream(bytesFilePath, FileMode.Open);
            FileStream streamImage = new FileStream(imageFilePath, FileMode.Open);
            FileStream output = new FileStream(outputPath, FileMode.Create);

            using (output)
            {
                using (streamBytes)
                {
                    using (streamImage)
                    {
                        byte[] bufferBytes = new byte[streamBytes.Length];
                        streamBytes.Read(bufferBytes, 0, (int)streamBytes.Length);

                        byte[] bufferImage = new byte[streamImage.Length];
                        streamImage.Read(bufferImage, 0, (int)streamImage.Length);

                        for (int i = 0; i < bufferImage.Length; i++)
                        {
                            for (int j = 0; j < bufferBytes.Length; j++)
                            {
                                if (bufferImage[i] == bufferBytes[j])
                                {
                                    output.WriteByte(bufferImage[i]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
