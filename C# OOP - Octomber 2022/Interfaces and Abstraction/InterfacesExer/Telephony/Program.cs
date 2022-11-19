using System;

namespace Telephony
{
    //Telephony
    //Create phone software that must support two main phone models with the following functionality:
    //  •	Smartphone: 
    //      •	Can call other phones.
    //      •	Can browse the world wide web.
    //  •	Stationary phone:
    //      •	Can only call other phones.
    //Input
    //The input will be of two lines:
    //  •	The first line consists of phone numbers: strings separated by spaces.
    //  •	The second line consists of websites: strings separated by spaces.
    //Output
    //  First, call all valid numbers in the order of input.
    //  •	If there is a character different from a digit in a number, print "Invalid number!" and continue with the next number.
    //  •	If the number is 10 digits long, you are making a call from your smartphone. Print "Calling... {number}".
    //  •	If the number is 7 digits long, you are making a call from your stationary phone. Print " Dialing... {number}".
    //  Next, browser all valid websites in the order of input.
    //  •	If there is a number in the input of the URLs, print "Invalid URL!" and continue with the next URLs.
    //  •	If the URL is valid, print "Browsing: {site}!"
    //Constraints
    //  •	Each site's URL should consist only of letters and symbols. No digits are allowed in the URL address.
    //  •	The phone numbers will always be 7 or 10 digits long. Nothing but digits are allowed in the number.
    //
    //Examples
    //Input
    //  0882134215 0882134333 0899213421 0558123 3333123
    //  http://softuni.bg http://youtube.com http://www.g00gle.com
    //Output
    //  Calling... 0882134215
    //  Calling... 0882134333
    //  Calling... 0899213421
    //  Dialing... 0558123
    //  Dialing... 3333123
    //  Browsing: http://softuni.bg!
    //  Browsing: http://youtube.com!
    //  Invalid URL!

    public class Program
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.InitiateCall(number);
                }
                else
                {
                    smartphone.InitiateCall(number);
                }
            }

            foreach (string site in sites)
            {
                smartphone.Browse(site);
            }
        }
    }
}
