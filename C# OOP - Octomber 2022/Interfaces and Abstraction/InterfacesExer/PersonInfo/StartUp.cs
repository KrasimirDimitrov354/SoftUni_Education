using System;

namespace PersonInfo
{
    //Define Interfaces
    //Define the following interfaces:
    //  •	IPerson with properties Name (string) and Age (int).
    //  •	IIdentifiable with property Id (string).
    //  •	IBirthable with property Birthdate (string).
    //
    //Define a class Citizen that implements all of the interfaces.
    //
    //Examples
    //Input     Output
    //Peter     Peter
    //25        25

    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
