using System;

namespace AuthorProblem
{
    //Attributes
    //Create attribute Author with a string element called name, that:
    //  •	Can be used over classes and methods.
    //  •	Allows multiple attributes of the same type.
    //
    //Create a class Tracker with a method void PrintMethodsByAuthor(). The method must print information about each method that is written by someone, in the following format:
    //  "{methodName} is written by {authorName}".

    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
