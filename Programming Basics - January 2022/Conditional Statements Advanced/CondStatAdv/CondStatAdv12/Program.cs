using System;

namespace CondStatAdv12
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double percent = 0;
            double commission = 0;

            if (sales < 0)
            {
                Console.WriteLine("error");
            }
            else if (city != "Sofia" & city != "Varna" & city != "Plovdiv")
            {
                Console.WriteLine("error");
            }
            else
            {
                switch (city)
                {
                    case "Sofia":
                        if (sales <= 500)
                        {
                            percent = 0.05;
                        }
                        else if (sales > 500 & sales <= 1000)
                        {
                            percent = 0.07;
                        }
                        else if (sales > 1000 & sales <= 10000)
                        {
                            percent = 0.08;
                        }
                        else if (sales > 10000)
                        {
                            percent = 0.12;
                        }
                        break;

                    case "Varna":
                        if (sales <= 500)
                        {
                            percent = 0.045;
                        }
                        else if (sales > 500 & sales <= 1000)
                        {
                            percent = 0.075;
                        }
                        else if (sales > 1000 & sales <= 10000)
                        {
                            percent = 0.1;
                        }
                        else if (sales > 10000)
                        {
                            percent = 0.13;
                        }
                        break;

                    case "Plovdiv":
                        if (sales <= 500)
                        {
                            percent = 0.055;
                        }
                        else if (sales > 500 & sales <= 1000)
                        {
                            percent = 0.08;
                        }
                        else if (sales > 1000 & sales <= 10000)
                        {
                            percent = 0.12;
                        }
                        else if (sales > 10000)
                        {
                            percent = 0.145;
                        }
                        break;
                }

                commission = percent * sales;
                Console.WriteLine($"{commission:f2}");
            }
        }
    }
}
