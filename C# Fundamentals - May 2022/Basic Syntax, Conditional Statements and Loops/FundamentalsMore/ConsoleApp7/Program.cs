using System;

namespace ConsoleApp7
{
    class Program
    {
        //Photo Gallery
        //Write a program, which receives image metadata as input and prints information about the image, such as its filename, date taken, size, resolution and aspect ratio.
        //Also, calculate the orientation of the image. The 3 orientations are: portrait, landscape and square.
        //Input
        //•	First line – the photo’s number – an integer in the range [0…9999]
        //•	Second, third, fourth line – the day, month and year the photo was taken – integers forming valid dates in the range [01/01/1990…31/12/2020]
        //•	Fifth, sixth line – the hours and minutes the photo was taken – integers in the range [0…23]
        //•	Seventh line – the photo’s size in bytes – integer in the range [0…999000000]
        //•	Eighth, ninth line – the photo’s resolution (width and height) in pixels – integers in the range[1…10000]
        //Output
        //•	The name should be printed in the format “DSC_xxxx.jpg”.
        //•	The date and time taken should be printed in the format “dd/mm/yyyy hh:mm”.
        //•	The size should be printed in standard human-readable format(i.e. 950 bytes = 950B, 500000 bytes = 500KB, 1500000 bytes = 1.5MB).
        //•	The resolution should be printed in the following format: “{width}x{height}”.
        //•	The orientation can be one of three valid values: portrait, landscape and square.
        //Examples
        //Input	    Output		                        Input	    Output
        //35        Name: DSC_0035.jpg                  533         Name: DSC_0533.jpg
        //25        Date Taken: 25 / 12 / 2003 12:03    20          Date Taken: 20 / 03 / 1993 11:33
        //12        Size: 1.5MB                         3           Size: 350KB
        //2003      Resolution: 5334x3006(landscape)    1993        Resolution: 768x1024(portrait)
        //12                                            11
        //3                                             33
        //1500000                                       350000
        //5334                                          768
        //3006	                                        1024
        //Input     Output
        //6552      Name: DSC_6552.jpg
        //12        Date Taken: 12 / 11 / 2012 15:33
        //11        Size: 850B
        //2012      Resolution: 1000x1000(square)
        //15
        //33
        //850
        //1000
        //1000
        static void Main()
        {
            string photoName = Console.ReadLine();
            string day = Console.ReadLine();
            string month = Console.ReadLine();
            string year = Console.ReadLine();
            string hours = Console.ReadLine();
            string minutes = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());
            string convertedSize = "";
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string orientation = "";

            string[] photoData = { day, month, hours, minutes };

            while (photoName.Length < 4)
            {
                photoName = '0' + photoName;
            }

            for (int i = 0; i < photoData.Length; i++)
            {
                while (photoData[i].Length < 2)
                {
                    photoData[i] = '0' + photoData[i];
                }
            }

            if (size < 1000)
            {
                convertedSize = $"{size}B";
            }
            else if (size >= 1000 && size < 1000000)
            {
                convertedSize = $"{size / 1000}KB";
            }
            else
            {
                convertedSize = $"{Math.Round(size / 1000000.0, 1)}MB";
            }

            if (width > height)
            {
                orientation = "landscape";
            }
            else if (height > width)
            {
                orientation = "portrait";
            }
            else
            {
                orientation = "square";
            }

            Console.WriteLine($"Name: DSC_{photoName}.jpg");
            Console.WriteLine($"Date Taken: {photoData[0]}/{photoData[1]}/{year} {photoData[2]}:{photoData[3]}");
            Console.WriteLine($"Size: {convertedSize}");
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
