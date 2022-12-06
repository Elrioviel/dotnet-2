using System;
using Triangle;

namespace TriangleUI
{
    class Program
    {
        public static double InputDouble(string displayMessage)
        {
            double doubleValue;
            Console.WriteLine(displayMessage);
            while (!double.TryParse(Console.ReadLine(), out doubleValue) && !TriangleShape.CheckSideValue(doubleValue))
            {
                Console.WriteLine("Invalid input");
            }
            return doubleValue;
        }

        public static string ShowResults(TriangleShape triangle)
        {
            string displayMessage = "Area of triangle: {0}\nPerimeter of triangle: {1}";
            return string.Format(displayMessage, triangle.CalculateTriangleArea(triangle), triangle.CalculateTrianglePerimeter(triangle));
        }

        static void Main(string[] args)
        {
            double a = InputDouble("Enter the length of the first side:");
            double b = InputDouble("Enter the length of the second side:");
            double c = InputDouble("Enter the length of the third side:");
            TriangleShape triangle = TriangleShape.Create(a, b, c);
            Console.WriteLine(ShowResults(triangle));
        }
    }
}
