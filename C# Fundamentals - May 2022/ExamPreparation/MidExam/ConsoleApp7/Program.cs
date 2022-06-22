using System;

namespace ConsoleApp7
{
    class Program
    {
        //Counter-Strike
        //Write a program that keeps track of every won battle against an enemy.
        //
        //You will receive initial energy.
        //Afterward you will start receiving the distance you need to reach an enemy until the "End of battle" command is given or you run out of energy.
        //
        //The energy you need for reaching an enemy is equal to the distance you receive. Each time you reach an enemy, you win a battle and your energy is reduced.
        //Otherwise, if you don't have enough energy to reach an enemy, end the program and print: "Not enough energy! Game ends with {count} won battles and {energy} energy".
        //
        //Every third won battle increases your energy with the value of your current count of won battles.
        //Upon receiving the "End of battle" command, print the count of won battles in the following format:
        //  "Won battles: {count}. Energy left: {energy}" 
        //
        //Input / Constraints
        //  •	On the first line, you will receive initial energy – an integer [1-10000].
        //  •	On the following lines, you will be receiving the distance of an enemy – an integer [1-10000]
        //Output
        //  •	The description contains the proper output messages for each case and the format they should be printed.

        //Examples
        //Input     Output                                                          Comments
        //100       Not enough energy! Game ends with 7 won battles and 0 energy    The initial energy is 100.
        //10                                                                        The first distance is 10 so we subtract 10 from 100 and we consider this a won battle.
        //10                                                                        We are left with 90 energy. Next distance is 10 - 80 energy left.
        //10                                                                        Next distance is 10 - 3 won battles and 70 energy.
        //1                                                                         Since we have 3 won battles we increase the energy with the current count of won battles.
        //2                                                                         In this case it is 3, thus the energy becomes 73.
        //3                                                                         The last distance we receive (10) is unreachable, since we have 0 energy left.
        //73                                                                        We print the appropriate message and the program ends.
        //10
        //
        //Input             Output
        //200               Won battles: 4. Energy left: 94
        //54
        //14
        //28
        //13
        //End of battle

        static void Main()
        {
            short playerEnergy = short.Parse(Console.ReadLine());
            short battlesWon = 0;
            bool energyLeft = true;

            while (energyLeft)
            {
                string input = Console.ReadLine();

                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {battlesWon}. Energy left: {playerEnergy}");
                    break;
                }
                else
                {
                    short enemyEnergy = short.Parse(input);

                    if (playerEnergy >= enemyEnergy)
                    {
                        battlesWon++;
                        playerEnergy -= enemyEnergy;

                        if (battlesWon % 3 == 0)
                        {
                            playerEnergy += battlesWon;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {playerEnergy} energy");
                        energyLeft = false;
                    }
                }
            }
        }
    }
}
