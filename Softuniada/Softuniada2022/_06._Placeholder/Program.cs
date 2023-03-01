using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Placeholder
{
    class Program
    {
        static void Main()
        {
            int figureCount = int.Parse(Console.ReadLine());
            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < figureCount; i++)
            {
                int[] figureDimensions = Console.ReadLine()
                    .Split(' ')
                    .Select(d => int.Parse(d))
                    .ToArray();

                Figure figure = new Figure(figureDimensions[0], figureDimensions[1], figureDimensions[2]);
                figures.Add(figure);
            }

            figures = figures.OrderBy(f => f.Length).ToList();

            for (int i = figureCount - 1; i >= 0; i--)
            {
                var currentFigure = figures[i];

                if (i != 0)
                {
                    var nextFigure = figures[i - 1];

                    if (currentFigure.Width < nextFigure.Width)
                    {
                        int tempLength = currentFigure.Length;
                        currentFigure.Length = currentFigure.Width;
                        currentFigure.Width = tempLength;

                        tempLength = nextFigure.Length;
                        nextFigure.Length = nextFigure.Width;
                        nextFigure.Width = tempLength;
                    }
                }
            }

            figures = figures.OrderBy(f => f.Width).ToList();
        }
    }

    class Figure
    {
        public Figure(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}
