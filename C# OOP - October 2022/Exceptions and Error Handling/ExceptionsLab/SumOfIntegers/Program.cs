using System;

namespace SumOfIntegers
{
    //Sum of Integers
    //You will receive a sequence of elements of different types, separated by space. Your task is to calculate the sum of all valid integer numbers in the input.
    //
    //Try to add each element of the array to the sum and write messages for the possible exceptions while processing the element.
    //  •	If you receive an element which is not in the correct format, throw a FormatException with the following message:
    //      "The element '{element}' is in wrong format!".
    //  •	If you receive an element which is out of the integer type range throw an OverflowException with the following message:
    //      "The element '{element}' is out of range!".
    //
    //After each processed element print the following message: "Element '{element}' processed - current sum: {sum}".
    //At the end print the total sum of all integers: "The total sum of all integers is: {sum}".
    //
    //Examples
    //Input                                         Output
    //2147483649 2 3.4 5 invalid 24 -4              The element '2147483649' is out of range!
    //                                              Element '2147483649' processed - current sum: 0
    //                                              Element '2' processed - current sum: 2
    //                                              The element '3.4' is in wrong format!
    //                                              Element '3.4' processed - current sum: 2
    //                                              Element '5' processed - current sum: 7
    //                                              The element 'invalid' is in wrong format!
    //                                              Element 'invalid' processed - current sum: 7
    //                                              Element '24' processed - current sum: 31
    //                                              Element '-4' processed - current sum: 27
    //                                              The total sum of all integers is: 27
    //
    //Input                                         Output
    //9876 string 10 -2147483649 -8 3 4.86555 8     Element '9876' processed - current sum: 9876
    //                                              The element 'string' is in wrong format!
    //                                              Element 'string' processed - current sum: 9876
    //                                              Element '10' processed - current sum: 9886
    //                                              The element '-2147483649' is out of range!
    //                                              Element '-2147483649' processed - current sum: 9886
    //                                              Element '-8' processed - current sum: 9878
    //                                              Element '3' processed - current sum: 9881
    //                                              The element '4.86555' is in wrong format!
    //                                              Element '4.86555' processed - current sum: 9881
    //                                              Element '8' processed - current sum: 9889
    //                                              The total sum of all integers is: 9889

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            long sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string element = input[i];

                try
                {
                    sum += ProcessElement(element);
                }
                catch (FormatException format)
                {
                    Console.WriteLine(format.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int ProcessElement(string element)
        {
            if (long.TryParse(element, out long result))
            {
                return Convert.ToInt32(result);
            }
            else
            {
                throw new FormatException($"The element '{element}' is in wrong format!");
            }
        }
    }
}
