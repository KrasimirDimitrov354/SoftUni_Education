using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        //Merging Lists
        //You are going to receive two lists of numbers.
        //Create a list that contains the numbers from both of the lists.
        //The first element should be from the first list, the second from the second list, and so on.
        //If the length of the two lists is not equal, just add the remaining elements at the end of the list.
        //Example
        //Input                         Output
        //3 5 2 43 12 3 54 10 23        3 76 5 5 2 34 43 2 12 4 3 12 54 10 23
        //76 5 34 2 4 12
        //Input                         Output
        //76 5 34 2 4 12                76 3 5 5 34 2 2 43 4 12 12 3 54 10 23
        //3 5 2 43 12 3 54 10 23

        private static void AddElement(List<int> listToRemoveFrom, List<int> listToAddTo)
        {
            int num = listToRemoveFrom[0];
            listToAddTo.Add(num);
            listToRemoveFrom.Remove(num);
        }

        static void Main()
        {
            List<int> firstList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> mergedList = new List<int>();

            bool firstListHasElements = firstList.Count != 0;
            bool secondListHasElements = secondList.Count != 0;

            while (firstListHasElements || secondListHasElements)
            {
                firstListHasElements = firstList.Count != 0;
                if (firstListHasElements)
                {
                    AddElement(firstList, mergedList);
                }

                secondListHasElements = secondList.Count != 0;
                if (secondListHasElements)
                {
                    AddElement(secondList, mergedList);
                }
            }

            Console.WriteLine(string.Join(' ', mergedList));
        }
    }
}
