using System;
using System.Text;

namespace ConsoleApp5
{
    //Multiply Big Number
    //You are given two lines – the first one can be a really big number (0 to 10 power 50). The second one will be a single-digit number(0 to 9). Your task is to display the product of these numbers.
    //Note: do not use the BigInteger class.
    //Examples
    //Input     Output | Input       Output | Input                         Output
    //23        46     | 9999        89991  | 923847238931983192462832102   3695388955727932769851328408
    //2                | 9                  | 4

    class Program
    {
        static void Main()
        {
            string longNum = Console.ReadLine();
            int shortNum = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int numInMind = 0;

            if (shortNum == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = longNum.Length - 1; i >= 0; i--)
                {
                    int currentNum = int.Parse(longNum[i].ToString());
                    int multiplicationResult = (shortNum * currentNum) + numInMind;
                    numInMind = 0;

                    while (multiplicationResult >= 10)
                    {
                        multiplicationResult -= 10;
                        numInMind++;
                    }

                    result.Insert(0, multiplicationResult);

                    if (i == 0 && numInMind != 0)
                    {
                        result.Insert(0, numInMind);
                    }
                }

                Console.WriteLine(result);
            }            
        }
    }
}
