using System;

namespace Triangle
{
    public class TriangleShape
    {
        const double minLength = 0;

        public double A;
        public double B;
        public double C;
        private TriangleShape(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static bool CheckSideValue(double sideValue)
        {
            return sideValue > minLength;
        }
        public static bool CheckSidesValues(double a, double b, double c)
        {
            return CheckSideValue(a) && CheckSideValue(b) && CheckSideValue(c) && (a + b > c) && (a + c > b) && (b + c > a);
        }
        public static TriangleShape Create(double a, double b, double c)
        {
            if (CheckSidesValues(a, b, c))
            {
                TriangleShape triangle = new TriangleShape(a, b, c);
                return triangle;
            }
            else
            {
                throw new ArgumentException("Invalid sides' value(s)");
            }
        }
        public double CalculateTriangleArea(TriangleShape triangle)
        {
            double triangleSide = (triangle.A + triangle.B + triangle.C) / 2;
            return Math.Sqrt(triangleSide * (triangleSide - triangle.A) * (triangleSide - triangle.B) * (triangleSide - triangle.C));
        }
        public double CalculateTrianglePerimeter(TriangleShape triangle)
        {
            return triangle.A + triangle.B + triangle.C;
        }
    }
}
