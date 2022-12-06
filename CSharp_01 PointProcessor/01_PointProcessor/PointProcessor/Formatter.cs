using System;
using System.Globalization;

namespace PointProcessor
{
    public class Formatter
    {
        public static string Format(Point point)
        {
            if (point == null)
            {
                return null;
            }
            decimal XIntegerPart = GetIntegerPart(point.X);
            decimal XFractionalPart = GetFractionalPart(point.X);
            decimal YIntegerPart = GetIntegerPart(point.Y);
            decimal YFractionalPart = GetFractionalPart(point.Y);
            return string.Format(CultureInfo.GetCultureInfo("ru"), "X: {0, 4}{1, -5:.0###} Y: {2, 4}{3, -5:.0###}", XIntegerPart, XFractionalPart, YIntegerPart, YFractionalPart);
        }
        private static decimal GetFractionalPart(decimal decimalNumber)
        {
            return decimalNumber - GetIntegerPart(decimalNumber);
        }

        private static decimal GetIntegerPart(decimal decimalNumber)
        {
            return Math.Truncate(decimalNumber);
        }
    }
}
