using System;
using System.Text;

namespace _02._Rocket
{
    //Ракета
    //Да се напише програма която прочита от конзолата цяло число N и чертае ракета с размери като в примерите по-долу.
    //Ширината на фигурата е N + 5.
    //
    //Вход
    //  Входът е цяло четно число N в интервала [4…30].
    //Изход
    //  Текстови редове изобразяващи ракета както в примерите по-долу.
    //
    //Пример
    //Вход
    //  4
    //Изход
    //  ____^____
    //  ___/|\___
    //  __/|||\__
    //  _/.|||.\_
    //  /..|||..\
    //  _/.|||.\_
    //  ___|||___
    //  ___|||___
    //  ___|||___
    //  ___|||___
    //  ___~~~___
    //  __//!\\__
    //  _//.!.\\_
    //
    //Вход
    //  6
    //Изход
    //  _____^_____
    //  ____/|\____
    //  ___/|||\___
    //  __/.|||.\__
    //  _/..|||..\_
    //  /...|||...\
    //  _/..|||..\_
    //  ____|||____
    //  ____|||____
    //  ____|||____
    //  ____|||____
    //  ____|||____
    //  ____|||____
    //  ____~~~____
    //  ___//!\\___
    //  __//.!.\\__
    //  _//..!..\\_
    //
    //Вход
    //  8
    //Изход
    //  ______^______
    //  _____/|\_____
    //  ____/|||\____
    //  ___/.|||.\___
    //  __/..|||..\__
    //  _/...|||...\_
    //  /....|||....\
    //  _/...|||...\_
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____|||_____
    //  _____~~~_____
    //  ____//!\\____
    //  ___//.!.\\___
    //  __//..!..\\__
    //  _//...!...\\_

    class Program
    {
        static void Main()
        {
            int rocketSize = int.Parse(Console.ReadLine());
            int rocketWidth = rocketSize + 5;

            StringBuilder rocket = new StringBuilder();

            for (int i = 0; i < rocketWidth; i++)
            {
                if (i == (rocketWidth - 1) / 2)
                {
                    rocket.Append('^');
                }
                else
                {
                    rocket.Append('_');
                }
            }

            rocket.AppendLine();

            DrawPartOfRocket(rocket, rocketSize + 2, "/|\\");

            int rocketBodySize = rocketSize / 2 + 2;
            int bodyUnderscoreLength = rocketSize / 2;
            int bodyDotLength = 0;

            for (int i = 0; i < rocketBodySize; i++)
            {
                rocket.Append('_', bodyUnderscoreLength);
                rocket.Append('/');
                rocket.Append('.', bodyDotLength);

                rocket.Append("|||");

                rocket.Append('.', bodyDotLength);
                rocket.Append('\\');
                rocket.Append('_', bodyUnderscoreLength);

                rocket.AppendLine();

                if (i == rocketBodySize - 2)
                {
                    bodyUnderscoreLength++;
                    bodyDotLength--;
                }
                else
                {
                    bodyUnderscoreLength--;
                    bodyDotLength++;
                }
            }

            for (int i = 0; i < rocketSize; i++)
            {
                DrawPartOfRocket(rocket, rocketSize + 2, "|||");
            }

            DrawPartOfRocket(rocket, rocketSize + 2, "~~~");

            int rocketEngineSize = rocketSize / 2;
            int engineUnderscoreLength = rocketSize / 2;
            int engineDotLength = 0;

            for (int i = 0; i < rocketEngineSize; i++)
            {
                rocket.Append('_', engineUnderscoreLength);
                rocket.Append("//");
                rocket.Append('.', engineDotLength);

                rocket.Append('!');

                rocket.Append('.', engineDotLength);
                rocket.Append("\\\\");
                rocket.Append('_', engineUnderscoreLength);

                rocket.AppendLine();

                engineUnderscoreLength--;
                engineDotLength++;
            }

            Console.WriteLine(rocket);
        }

        private static void DrawPartOfRocket(StringBuilder rocket, int rocketPartWidth, string specialSymbol)
        {
            for (int i = 0; i <= rocketPartWidth; i++)
            {
                if (i == rocketPartWidth / 2)
                {
                    rocket.Append(specialSymbol);
                }
                else
                {
                    rocket.Append('_');
                }
            }

            rocket.AppendLine();
        }
    }
}
