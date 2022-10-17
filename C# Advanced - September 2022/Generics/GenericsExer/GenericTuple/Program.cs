using System;

namespace GenericTuple
{
    //Tuple
    //Implement a variant of the C# class Tuple that can hold two objects and print them in the format {item1} -> { item2}.
    //
    //Input
    //The input consists of three lines:
    //  •	The first one is holding a person's name and an address. They are separated by space(s).
    //      Your task is to collect them in the tuple and print them on the console. Format of the input:
    //      {first name} {last name} {address}
    //
    //  •	The second line holds a name of a person and the amount of beer (int) he can drink. Format:
    //      {name} {liters of beer}
    //
    //  •	The last line will hold an integer and a double. Format:
    //      {integer} {double}
    //Output
    //  •	Print the tuples’ items in format: {item1} -> {item2}
    //Constraints
    //  •	Create the class and make it have getters and setters for its class variables.
    //  •	The input will always be valid, no need to check it explicitly.
    //
    //Examples
    //Input                     Output
    //Adam Smith California     Adam Smith -> California
    //Mark 2                    Mark -> 2
    //23 21.23212321            23 -> 21.23212321
    //
    //Input                     Output
    //William Donovan York      William Donovan -> York
    //Richard 2999999           Richard -> 2999999
    //10 10                     10 -> 10

    public class Program
    {
        static void Main()
        {
            string[] input = GetInput();
            Tuple<string, string> firstTuple = new Tuple<string, string>(String.Join(' ', input, 0, 2), input[2]);

            input = GetInput();
            Tuple<string, int> secondTuple = new Tuple<string, int>(input[0], int.Parse(input[1]));

            input = GetInput();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }

        public static string[] GetInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
