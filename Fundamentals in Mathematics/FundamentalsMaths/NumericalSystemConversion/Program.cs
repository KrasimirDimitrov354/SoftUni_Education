using System;
using System.Text;

namespace NumericalSystemConversion
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter system to convert from - decimal, octal, hexadecimal or binary:");
            string system = Console.ReadLine();
            Console.WriteLine("Enter number:");
            string number = Console.ReadLine();
            Console.WriteLine("Enter system to convert to:");
            string systemToConvertTo = Console.ReadLine();

            Console.WriteLine(Convert(system, number, systemToConvertTo));
        }

        private static string Convert(string system, string number, string systemToConvertTo)
        {
            string converted = string.Empty;

            switch (systemToConvertTo)
            {
                case "decimal":
                    converted = GetDecimal(system, number);
                    break;
                case "octal":
                    converted = GetOctal(system, number);
                    break;
                case "hexadecimal":
                    converted = GetHexadecimal(system, number);
                    break;
                case "binary":
                    converted = GetBinary(system, number);
                    break;
            }

            return converted;
        }

        private static string GetDecimal(string system, string number)
        {
            StringBuilder converted = new StringBuilder();

            if (system == "octal" || system == "hexadecimal")
            {
                number = GetBinary(system, number);
            }

            int resultBinary = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentSum = (int)Char.GetNumericValue(number[i]) * (int)Math.Pow(2, number.Length - (i + 1));
                resultBinary += currentSum;
            }

            converted.Append(resultBinary);


            return converted.ToString();
        }

        private static string GetOctal(string system, string number)
        {
            StringBuilder converted = new StringBuilder();

            if (system == "decimal" || system == "hexadecimal")
            {
                number = GetBinary(system, number);
            }

            while (number.Length % 3 != 0)
            {
                number = number.Insert(0, "0");
            }

            int originalLength = number.Length / 3;

            for (int i = 0; i < originalLength; i++)
            {
                int first = (int)Char.GetNumericValue(number[0]) * (int)Math.Pow(2, 2);
                int second = (int)Char.GetNumericValue(number[1]) * (int)Math.Pow(2, 1);
                int third = (int)Char.GetNumericValue(number[2]) * (int)Math.Pow(2, 0);

                converted.Insert(converted.Length, first + second + third);
                number = number.Remove(0, 3);
            }

            return converted.ToString();
        }

        private static string GetHexadecimal(string system, string number)
        {
            StringBuilder converted = new StringBuilder();

            if (system == "octal" || system == "decimal")
            {
                number = GetBinary(system, number);
            }

            while (number.Length % 4 != 0)
            {
                number = number.Insert(0, "0");
            }

            int originalLength = number.Length / 4;

            for (int i = 0; i < originalLength; i++)
            {
                int first = (int)Char.GetNumericValue(number[0]) * (int)Math.Pow(2, 3);
                int second = (int)Char.GetNumericValue(number[1]) * (int)Math.Pow(2, 2);
                int third = (int)Char.GetNumericValue(number[2]) * (int)Math.Pow(2, 1);
                int fourth = (int)Char.GetNumericValue(number[3]) * (int)Math.Pow(2, 0);

                int result = first + second + third + fourth;

                if (result > 9)
                {
                    converted.Insert(converted.Length, (char)(result + 55));
                }
                else
                {
                    converted.Insert(converted.Length, result);
                }

                number = number.Remove(0, 4);
            }

            return converted.ToString();
        }

        private static string GetBinary(string system, string number)
        {
            StringBuilder converted = new StringBuilder();

            switch (system)
            {
                case "octal":
                    {
                        for (int i = 0; i < number.Length; i++)
                        {
                            decimal currentDigit = (decimal)Char.GetNumericValue(number[i]);
                            StringBuilder currentResult = GetCurrentResult(currentDigit);

                            while (currentResult.Length % 3 != 0)
                            {
                                currentResult.Insert(0, "0");
                            }

                            converted.Append(currentResult);
                        }
                        break;
                    }
                case "decimal":
                    {
                        converted.Append(GetCurrentResult(decimal.Parse(number)));
                        break;
                    }
                case "hexadecimal":
                    {
                        for (int i = 0; i < number.Length; i++)
                        {
                            decimal currentDigit = 0;

                            if (!Char.IsDigit(number[i]))
                            {
                                currentDigit = number[i] - 55;
                            }
                            else
                            {
                                currentDigit = (decimal)Char.GetNumericValue(number[i]);
                            }

                            StringBuilder currentResult = GetCurrentResult(currentDigit);

                            while (currentResult.Length % 4 != 0)
                            {
                                currentResult.Insert(0, "0");
                            }

                            converted.Append(currentResult);
                        }
                        break;
                    }
            }

            return converted.ToString();
        }

        public static StringBuilder GetCurrentResult(decimal number)
        {
            StringBuilder currentResult = new StringBuilder();

            if (number == 0)
            {
                currentResult.Insert(0, "0");
            }
            else
            {
                while (number >= 1)
                {
                    if (number % 2 == 0)
                    {
                        currentResult.Insert(0, "0");
                    }
                    else
                    {
                        currentResult.Insert(0, "1");
                    }

                    number = Math.Truncate(number / 2);
                }
            }          

            return currentResult;
        }
    }
}
