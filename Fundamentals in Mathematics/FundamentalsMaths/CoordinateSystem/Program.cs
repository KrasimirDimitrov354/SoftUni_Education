using System;
using System.Collections.Generic;
using System.Linq;

namespace CoordinateSystem
{
    class Program
    {
        static void Main()
        {
            Figure figure = GetFigure(Console.ReadLine());
            Console.WriteLine($"Surface of {figure.Type}: {figure.CalculateSurface()}");
        }

        public static Figure GetFigure(string input)
        {
            Figure figure = new Figure(input);
            int countOfPoints = 0;

            switch (input)
            {
                case "Square":
                case "Rectangle":
                case "Trapezoid":
                    countOfPoints = 4;
                    break;
                case "Triangle":
                    countOfPoints = 3;
                    break;
                case "Circle":
                    countOfPoints = 1;
                    break;
                case "Eclipse":
                    countOfPoints = 2;
                    break;
            }

            for (int i = 0; i < countOfPoints; i++)
            {
                int[] coordinates = Console.ReadLine()
                    .Split(", ")
                    .Select(c => int.Parse(c))
                    .ToArray();

                char currentPoint = (char)(i + 65);

                figure.Points.Add(currentPoint, new Point(coordinates[0], coordinates[1]));
            }

            return figure;
        }
    }

    public class Figure
    {
        public Figure(string type)
        {
            Type = type;
            Points = new Dictionary<char, Point>();
        }

        public string Type { get; private set; }
        public Dictionary<char, Point> Points { get; set; }

        public double CalculateSurface()
        {
            switch (Type)
            {
                case "Square":
                    double x = GetBase(Points['A'].xAxis, Points['B'].xAxis);
                    return Math.Pow(x, 2);
                case "Rectangle":
                    double b = GetBase(Points['A'].xAxis, Points['B'].xAxis);
                    double h = GetHeight(Points['C'].yAxis, Points['A'].yAxis);
                    return b * h;
                case "Trapezoid":
                    double smallBase = GetBase(Points['C'].xAxis, Points['D'].xAxis);
                    double largeBase = GetBase(Points['A'].xAxis, Points['B'].xAxis);
                    double height = GetHeight(Points['C'].yAxis, Points['A'].yAxis);
                    return ((largeBase + smallBase) * height) / 2;
                case "Triangle":
                    double triangleBase = GetBase(Points['A'].xAxis, Points['B'].xAxis);
                    double triangleHeight = GetHeight(Points['C'].yAxis, Points['A'].yAxis);
                    return (triangleBase * triangleHeight) / 2;
                case "Circle":
                    break;
                case "Eclipse":
                    break;
            }

            return 0;
        }

        private double GetBase(double firstPoint, double secondPoint)
        {
            if ((firstPoint < 0 && secondPoint > 0) ||
                (firstPoint > 0 && secondPoint < 0))
            {
                return Math.Abs(firstPoint) + Math.Abs(secondPoint);
            }
            else
            {
                if (firstPoint < secondPoint)
                {
                    return secondPoint - firstPoint;
                }
                else
                {
                    return Math.Abs(firstPoint) - Math.Abs(secondPoint);
                }
            }
        }

        private double GetHeight(double heightPoint, double basePoint)
        {
            return Math.Abs(heightPoint) - Math.Abs(basePoint);
        }
    }

    public class Point
    {
        public Point(double xAxis, double yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }

        public double xAxis { get; private set; }
        public double yAxis { get; private set; }
    }
}
