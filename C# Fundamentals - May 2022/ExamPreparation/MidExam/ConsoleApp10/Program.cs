using System;

namespace ConsoleApp10
{
    class Program
    {
        //Guinea Pig
        //Merry has a guinea pig named Puppy that she loves very much. Every month she goes to the nearest pet store and buys him everything he needs – food, hay, and cover.
        //
        //On the first three lines you will receive the quantity of food, hay, and cover which Merry buys for a month (30 days). On the fourth line, you will receive the guinea pig's weight.
        //
        //Every day Puppy eats 300 gr of food. Every second day Merry first feeds the pet, then gives it a certain amount of hay equal to 5% of the rest of the food.
        //On every third day, Merry puts Puppy cover with a quantity of 1/3 of its weight.
        //
        //Calculate whether the quantity of food, hay, and cover, will be enough for a month.
        //If Merry runs out of food, hay, or cover, stop the program!
        //
        //Input
        //  •	On the first line – quantity food in kilograms - a floating-point number in the range [0.0 – 10000.0]
        //  •	On the second line – quantity hay in kilograms - a floating-point number in the range [0.0 – 10000.0]
        //  •	On the third line – quantity cover in kilograms - a floating-point number in the range [0.0 – 10000.0]
        //  •	On the fourth line – guinea's weight in kilograms - a floating-point number in the range [0.0 – 10000.0]
        //Output
        //  •	If the food, the hay, and the cover are enough, print:
        //      o   "Everything is fine! Puppy is happy! Food: {excessFood}, Hay: {excessHay}, Cover: {excessCover}."
        //  •	If one of the things is not enough, print:
        //      o   "Merry must go to the pet store!"
        //The output values must be formatted to the second decimal place!
        //
        //Examples
        //Input         Output
        //10            Everything is fine! Puppy is happy! Food: 1.00, Hay: 1.10, Cover: 1.87.
        //5
        //5.2
        //1
        //Comments
        //You receive food – 10000, hay – 5000, cover – 5200, weight – 1000 (in grams). 
        //On the first day, Merry gives Puppy 300gr food – 9700gr food left.
        //On the second day, the food left is 9400gr, so the needed hay is 9400 * 5%  = 470, and the hay left is 4530. 
        //On the third day, the cover left is 4866.67, and the food left is 9100, and so on.
        //On the last day, Merry has: food – 1.00, hay – 1.10, and cover – 1.87.
        //
        //Input         Output                              Input           Output
        //1             Merry must go to the pet store!     9               Merry must go to the pet store!
        //1.5                                               5
        //3                                                 5.2
        //1.5                                               1

        static void Main()
        {
            decimal food = decimal.Parse(Console.ReadLine());
            decimal hay = decimal.Parse(Console.ReadLine());
            decimal cover = decimal.Parse(Console.ReadLine());
            decimal weight = decimal.Parse(Console.ReadLine());
            bool everythingIsFine = true;

            for (int i = 1; i <= 30; i++)
            {
                food -= 0.3m;

                if (i % 2 == 0)
                {
                    hay -= food * 0.05m;
                }

                if (i % 3 == 0)
                {
                    cover -= weight / 3;
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    everythingIsFine = false;
                    break;
                }
            }

            if (everythingIsFine)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
