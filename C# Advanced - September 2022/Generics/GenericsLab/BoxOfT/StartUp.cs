using System;

namespace BoxOfT
{
    //Box of T
    //Create a public StartUp class with the namespace BoxOfT.
    //Then create a class Box<> that can store anything.
    //
    //It should have two public methods:
    //  •	void Add(element) – adds an element on the top of the collection.
    //  •	element Remove() – removes the topmost element.
    //It must also have a property Count - the number of elements in the collection.

    public class StartUp
    {
        static void Main()
        {
            Box<int> box = new Box<int>();

            box.Add(1);
            box.Add(2);
            box.Add(3);

            Console.WriteLine(box.Remove());

            box.Add(4);
            box.Add(5);

            Console.WriteLine(box.Remove());
        }
    }
}
