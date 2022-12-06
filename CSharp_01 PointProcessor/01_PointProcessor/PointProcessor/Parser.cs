using System;
using System.Globalization;

namespace PointProcessor
{
    public static class Parser
    {
        private const int CoordinatesAmount = 2;
        private const int CoordinateXIndex = 0;
        private const int CoordinateYIndex = 1;
        private const char CoordinateDelimeter = ',';
        public static bool TryParsePoint(string line, out Point point)
        {
            if (line != null)
            {
                string[] coordinates = line.Split(CoordinateDelimeter);
                if (coordinates.Length == CoordinatesAmount && TryParseCoordinate(coordinates[CoordinateXIndex], out decimal xValue) && TryParseCoordinate(coordinates[CoordinateYIndex], out decimal yValue))
                {
                    point = new Point(xValue, yValue);
                    return true;
                }
            }
            point = null;
            return false;
        }
        private static bool TryParseCoordinate(string value, out decimal coordinate)
        {
            return decimal.TryParse(value, NumberStyles.Any, new CultureInfo("En-US"), out coordinate);
        }
    }
}
