using System;

namespace WhileLoopMore3
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";

            int counterC = 0;
            int counterO = 0;
            int counterN = 0;

            while (true)
            {
                string input = Console.ReadLine();

                //Проверка дали не е стигнат края на входните данни
                if (input != "End")
                {
                    char symbol = char.Parse(input);

                    //проверка дали въведения символ е част от латинската азбука
                    if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                    {
                        //проверка дали въдедената буква е една от трите специални букви както е указано в условието на задачата
                        if ((symbol == 'c') || (symbol == 'o') || (symbol == 'n'))
                        {                            
                            switch (symbol)
                            {
                                //проверка дали специалната буква е въведена повече от веднъж, и ако да - добавянето и към крайния резултат
                                case 'c':
                                    counterC++;

                                    if (counterC > 1)
                                    {
                                        result += symbol.ToString();
                                    }
                                    break;
                                case 'o':
                                    counterO++;

                                    if (counterO > 1)
                                    {
                                        result += symbol.ToString();
                                    }
                                    break;
                                case 'n':
                                    counterN++;

                                    if (counterN > 1)
                                    {
                                        result += symbol.ToString();
                                    }
                                    break;
                                default:
                                    break;
                            }

                            //проверка дали всяка от трите специални букви е въведена повече от веднъж, и ако да - добавяне на празно пространство към крайния резултат
                            //зануляване на броячите за специални букви с цел следене за добавяне на следващо празно място
                            if ((counterC > 0) && (counterO > 0) && (counterN > 0))
                            {
                                result += " ";
                                counterC = 0;
                                counterO = 0;
                                counterN = 0;
                            }
                        }
                        //добавяне на въведения символ към крайния резултат
                        else
                        {
                            result += symbol.ToString();
                        }
                    }
                }
                //прекъсване на while цикъла при въвеждане на "End"
                else
                {
                    break;
                }
            }

            //проверка дали има букви въведени след последното празно място, и ако да - премахването им
            if (result == "")
            {
                result = " ";
            }
            else if (result.EndsWith(" ") == false)
            {
                result = result.Remove(result.LastIndexOf(" ") + 1);
            }
            Console.WriteLine(result);
        }
    }
}
