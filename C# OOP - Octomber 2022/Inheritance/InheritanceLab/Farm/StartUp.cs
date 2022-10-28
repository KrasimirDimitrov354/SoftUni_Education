using System;

namespace Farm
{
    //Single, Multiple and Hierarchical Inheritance
    //
    //Create base class Animal with a single public method Eat() that prints "eating...".
    //
    //Then create the following classes:
    //  •	Dog with a single public method Bark() that prints "barking...".
    //  •	Cat with a single public method Meow() that prints "meowing...".
    //  •	Puppy with a single public method Weep() that prints "weeping...".
    //
    //Dog and Cat should inherit from Animal. Puppy should inherit from Dog.

    public class StartUp
    {
        static void Main()
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
