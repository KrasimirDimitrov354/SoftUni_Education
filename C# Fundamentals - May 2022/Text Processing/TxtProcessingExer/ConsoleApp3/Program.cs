using System;
using System.Linq;

namespace ConsoleApp3
{
    //Extract File
    //Create a program that reads the path to a file and subtracts the file name and its extension.
    //Examples
    //Input
    //  C:\Internal\training-internal\Template.pptx
    //Output
    //  File name: Template
    //  File extension: pptx
    //
    //Input
    //  C:\Projects\Data-Structures\LinkedList.cs
    //Output
    //  File name: LinkedList
    //  File extension: cs

    class Program
    {
        static void Main()
        {
            string filePath = Console.ReadLine();
            string[] fileInfo = filePath.Substring(filePath.LastIndexOf('\\') + 1)
                .Split('.')
                .ToArray();

            Console.WriteLine($"File name: {fileInfo[0]}");
            Console.WriteLine($"File extension: {fileInfo[1]}");
        }
    }
}
