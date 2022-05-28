using System;

namespace ConsoleApp3
{
    class Program
    {
        //3.	Gaming Store
        //Create a program, which helps you buy the games. The valid games are the following games in this table:
        //Name                          Price
        //OutFall 4	                    $39.99
        //CS: OG                        $15.99
        //Zplinter Zell	                $19.99
        //Honored 2	                    $59.99
        //RoverWatch                    $29.99
        //RoverWatch Origins Edition    $39.99
        //
        //On the first line, you will receive your current balance – a floating-point number in the range [0.00…5000.00].
        //Until you receive the command "Game Time", you have to keep buying games. When a game is bought, the user’s balance decreases by the price of the game.
        //
        //Additionally, the program should obey the following conditions:
        //•	If a game the user is trying to buy is not present in the table above, print "Not Found" and read the next line.
        //•	If at any point, the user has $0 left, print "Out of money!" and end the program.
        //•	Alternatively, if the user is trying to buy a game that they can’t afford, print "Too Expensive" and read the next line.
        //•	If the game exists and the player has the money for it, print "Bought {nameOfGame}"
        //When you receive "Game Time", print the user’s remaining money and total spent on games, rounded to the 2nd decimal place.
        //Examples
        //Input                         Output
        //120                           Bought RoverWatch
        //RoverWatch                    Bought Honored 2
        //Honored 2                     Total spent: $89.98. Remaining: $30.02
        //Game Time   
        //Input                         Output
        //19.99                         Not Found
        //Reimen origin                 Too Expensive
        //RoverWatch                    Bought Zplinter Zell
        //Zplinter Zell                 Out of money!
        //Game Time
        //Input                         Output
        //79.99                         Bought OutFall 4
        //OutFall 4                     Bought RoverWatch Origins Edition
        //RoverWatch Origins Edition    Total spent: $79.98. Remaining: $0.01
        //Game Time

        static void Main()
        {
            double balance = double.Parse(Console.ReadLine());
            double expenses = 0.0;
            double gamePrice = 0.0;
            bool noMoney = false;

            while (true)
            {
                if (noMoney)
                {
                    break;
                }

                string input = Console.ReadLine();
                
                if (input == "Game Time")
                {
                    break;
                }
                else
                {
                    bool gameIsPresent = (input == "OutFall 4" || input == "CS: OG" || input == "Zplinter Zell" ||
                        input == "Honored 2" || input == "RoverWatch" || input == "RoverWatch Origins Edition");

                    if (gameIsPresent)
                    {
                        switch (input)
                        {
                            case "OutFall 4":
                            case "RoverWatch Origins Edition":
                                gamePrice = 39.99;
                                break;
                            case "CS: OG":
                                gamePrice = 15.99;
                                break;
                            case "Zplinter Zell":
                                gamePrice = 19.99;
                                break;
                            case "Honored 2":
                                gamePrice = 59.99;
                                break;
                            case "RoverWatch":
                                gamePrice = 29.99;
                                break;
                        }

                        if (balance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {input}");
                            balance -= gamePrice;
                            expenses += gamePrice;

                            if (balance == 0)
                            {
                                noMoney = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                }
            }

            if (noMoney)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${expenses:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}