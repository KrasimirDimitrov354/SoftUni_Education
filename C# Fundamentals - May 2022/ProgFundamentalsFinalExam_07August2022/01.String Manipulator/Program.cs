using System;
using System.Linq;
using System.Text;

namespace _01.String_Manipulator
{
    class Program
    {
        private static StringBuilder Print(StringBuilder input)
        {
            return input;
        }

        private static void Translate(StringBuilder input, string toBeReplaced, string toReplaceWith)
        {
            input.Replace(toBeReplaced, toReplaceWith);
            Console.WriteLine(Print(input));
        }

        private static void Includes(StringBuilder input, string stringToCheck)
        {
            string convertedInput = input.ToString();

            if (convertedInput.Contains(stringToCheck))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static void Start(StringBuilder input, string stringToCheck)
        {
            string convertedInput = input.ToString();

            if (convertedInput.StartsWith(stringToCheck))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static StringBuilder Lowercase(StringBuilder input)
        {
            string convertedInput = input.ToString().ToLower();
            input = new StringBuilder(convertedInput);
            Console.WriteLine(Print(input));
            return input;
        }

        private static void FindIndex(StringBuilder input, string toFind)
        {
            string convertedInput = input.ToString();
            Console.WriteLine(convertedInput.LastIndexOf(toFind));
        }

        private static void Remove(StringBuilder input, int startIndex, int count)
        {
            input.Remove(startIndex, count);
            Console.WriteLine(Print(input));
        }

        static void Main()
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "End")
                {
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "Translate":
                            Translate(input, command[1], command[2]);
                            break;
                        case "Includes":
                            Includes(input, command[1]);
                            break;
                        case "Start":
                            Start(input, command[1]);
                            break;
                        case "Lowercase":
                            input = Lowercase(input);
                            break;
                        case "FindIndex":
                            FindIndex(input, command[1]);
                            break;
                        case "Remove":
                            Remove(input, int.Parse(command[1]), int.Parse(command[2]));
                            break;
                    }
                }
            }
        }
    }
}
