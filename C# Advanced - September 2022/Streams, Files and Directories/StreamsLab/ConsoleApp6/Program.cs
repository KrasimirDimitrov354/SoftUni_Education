using System.IO;

namespace SplitMergeBinaryFile
{
    //Split/Merge Binary Files
    //You are given an input binary file (e.g. example.png). Write a program to split it into two equal-sized files (e.g. part-1.bin and part-2.bin).
    //When the input file size is an odd number, the first part should be 1 byte bigger than the second.
    //
    //After splitting the input file, join the obtained files into a new file (e.g. example-joined.png). The obtained result file should be the same as the initial input file.

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open);
            FileStream outputOne = new FileStream(partOneFilePath, FileMode.Create);
            FileStream outputTwo = new FileStream(partTwoFilePath, FileMode.Create);

            using (sourceStream)
            {
                using (outputOne)
                {
                    using (outputTwo)
                    {
                        byte[] sourceBuffer = new byte[sourceStream.Length];
                        sourceStream.Read(sourceBuffer, 0, (int)sourceStream.Length);

                        if (sourceBuffer.Length % 2 == 0)
                        {
                            for (int i = 0; i < sourceBuffer.Length / 2; i++)
                            {
                                outputOne.WriteByte(sourceBuffer[i]);
                            }

                            for (int j = sourceBuffer.Length / 2; j < sourceBuffer.Length; j++)
                            {
                                outputTwo.WriteByte(sourceBuffer[j]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < (sourceBuffer.Length / 2) + 1; i++)
                            {
                                outputOne.WriteByte(sourceBuffer[i]);
                            }

                            for (int j = (sourceBuffer.Length / 2) + 1; j < sourceBuffer.Length; j++)
                            {
                                outputTwo.WriteByte(sourceBuffer[j]);
                            }
                        }                       
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            FileStream streamOne = new FileStream(partOneFilePath, FileMode.Open);
            FileStream streamTwo = new FileStream(partTwoFilePath, FileMode.Open);
            FileStream joinedOutput = new FileStream(joinedFilePath, FileMode.Create);

            using (joinedOutput)
            {
                using (streamOne)
                {
                    using (streamTwo)
                    {
                        byte[] sourceOne = new byte[streamOne.Length];
                        streamOne.Read(sourceOne, 0, (int)streamOne.Length);

                        byte[] sourceTwo = new byte[streamTwo.Length];
                        streamTwo.Read(sourceTwo, 0, (int)streamTwo.Length);

                        for (int i = 0; i < sourceOne.Length; i++)
                        {
                            joinedOutput.WriteByte(sourceOne[i]);
                        }

                        for (int j = 0; j < sourceTwo.Length; j++)
                        {
                            joinedOutput.WriteByte(sourceTwo[j]);
                        }
                    }
                }
            }
        }
    }
}
