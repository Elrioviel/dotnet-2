using System;
using System.Collections.Generic;
using GCD;

namespace Task_A
{
    class Program
    {
        const string nonValidInput = "Invalid input";
        const int limit = 0;
        const int minAmount = 2;
        const int maxAmount = 5;

        public static int GetInt(string message, int? maxAmount)
        {
            Console.WriteLine(message);
            int intValue;
            while (!(int.TryParse(Console.ReadLine(), out intValue) && (intValue >= limit) && (!maxAmount.HasValue || intValue <= maxAmount.Value)))
            {
                Console.WriteLine(nonValidInput);
            }
            return intValue;
        }

        //public static int GetAmountOfNumbers()
        //{
        //    int intValue;
        //    Console.WriteLine("How many numbers you wish to get the GCD of?");
        //    while (!((int.TryParse(Console.ReadLine(), out intValue)) && (intValue >= minAmount && intValue <= maxAmount)))
        //    {
        //        Console.WriteLine(nonValidInput);
        //    }
        //    return intValue;
        //}

        public static int[] FillIntegersArray()
        {

            int numberOfIntegers = GetInt("How many numbers you wish to get the GCD of?", null);
            List<int> integersList = new List<int>();
            for (int i = 0; i < numberOfIntegers; i++)
            {
                integersList.Add(GetInt("Enter an integer:", maxAmount));
            }
            return integersList.ToArray();
        }
 
        static void Main(string[] args)
        {
            var integersArray = FillIntegersArray();
            long timeSpentOnStandartGCD;
            long timeSpentOnBinaryGCD;
            var euclideanResult = GCDFinder.CalculateEuclideanGCD(out timeSpentOnStandartGCD, integersArray);
            var binaryResult = GCDFinder.CalculateBinaryEuclideanGCD(out timeSpentOnBinaryGCD, integersArray);
            Console.WriteLine($"The greatest common divisor by euclidean algorithm: {euclideanResult}, execution time: {timeSpentOnStandartGCD} ms");
            Console.WriteLine($"The greatest common divisor by binary euclidean algorithm: {binaryResult}, execution time: {timeSpentOnBinaryGCD} ms");
        }
    }
}
