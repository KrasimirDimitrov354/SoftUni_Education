using System;

namespace GenericTriple
{
    //Threeuple
    //Create a Class Threeuple. It must hold three objects with their own getters and setters.
    //
    //Input
    //The input consists of three lines:
    //  •	The first one is holding a name, an address and a town. Format of the input:
    //      {first name} {last name} {address} {town}
    //      Note: The town name can be comprised of more than one word.
    //
    //  •	The second line is holding a name, beer liters and a boolean variable with values "drunk" or "not". Format:
    //      {name} {liters of beer} {boolean variable}
    //
    //  •	The last line will hold a name, a bank balance (double) and a bank name. Format:
    //      {name} {account balance} {bank name}
    //Output
    //  •	Print the Threeuples' objects in format:
    //      "{firstElement} -> {secondElement} -> {thirdElement}"
    //
    //Examples
    //Input
    //  Adam Smith Wallstreet New York
    //  Mark 18 drunk
    //  Karren 0.10 USBank
    //Output
    //  Adam Smith -> Wallstreet -> New York
    //  Mark -> 18 -> True
    //  Karren -> 0.1 -> USBank
    //Input
    //  Anatoly Andreevich Kutuzova Kaliningrad
    //  Marley 9 not
    //  Grant 2 NGB
    //Output
    //  Anatoly Andreevich -> Kutuzova -> Kaliningrad
    //  Marley -> 9 -> False
    //  Grant -> 2 -> NGB

    public class Program
    {
        static void Main()
        {
            string[] input = GetInput();
            Threeuple<string, string, string> firstTriple = new Threeuple<string, string, string>(
                String.Join(' ', input, 0, 2),
                input[2],
                String.Join(' ', input, 3, input.Length - 3));

            input = GetInput();
            Threeuple<string, int, bool> secondTriple = new Threeuple<string, int, bool>(
                input[0],
                int.Parse(input[1]),
                GetBool(input[2]));

            input = GetInput();
            Threeuple<string, double, string> thirdTriple = new Threeuple<string, double, string>(
                input[0],
                double.Parse(input[1]),
                input[2]);

            Console.WriteLine(firstTriple.ToString());
            Console.WriteLine(secondTriple.ToString());
            Console.WriteLine(thirdTriple.ToString());
        }

        private static bool GetBool(string input)
        {
            if (input == "drunk")
            {
                return true;
            }

            return false;
        }

        public static string[] GetInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
