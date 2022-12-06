using System;
using NthRoot;

namespace Task_A
{
    class Program
    {
        const double accuracyLimit = 0.11;
        const double numberLimit = 0;
        const int exponentLimit = 0;
        const string nonValidInput = "Invalid input";
        const string EqualityMessage = "Results are equal.";
        const string NonequalityMessage = "Results are unequal.";
        public static double number, accuracy;
        public static int exponent;
        public static void GetInput(double numberLimit, int exponentLimit, double accuracyLimit)
        {
            number = InputDouble("Enter the base number:", numberLimit);
            exponent = InputInt("Enter the root's degree:", exponentLimit);
            accuracy = InputDouble("Enter the accuracy value:", accuracyLimit);
        }
        public static int InputInt(string displayMessage, int limit)
        {
            int intValue;
            Console.WriteLine(displayMessage);
            while (!(int.TryParse(Console.ReadLine(), out intValue)) && !(intValue > limit))
            {
                Console.WriteLine(nonValidInput);
            }
            return intValue;
        }
        public static double InputDouble(string displayMessage, double limit)
        {
            double doubleValue;
            Console.WriteLine(displayMessage);
            while (!(double.TryParse(Console.ReadLine(), out doubleValue)) && !(doubleValue > limit))
            {
                Console.WriteLine(nonValidInput);
            }
            return doubleValue;
        }
        public static void ShowResults(string displayMessage, int exponent, double number, double result)
        {
            Console.WriteLine(displayMessage, exponent, number, result);
        }
        public static void CompareResults(double newtonsResult, double standardResult)
        {
            bool IsEqual = Math.Abs(newtonsResult - standardResult) <= accuracy;
            string resultsEqualityMessage = IsEqual ? EqualityMessage : NonequalityMessage;
            Console.WriteLine(resultsEqualityMessage);
        }
        static void Main(string[] args)
        {
            GetInput(numberLimit, exponentLimit, accuracyLimit);
            NthRootCalculator nthRoot = new NthRootCalculator(number, exponent, accuracy);
            ShowResults("The {0}th root of {1} by Newton's method is: {2}", exponent, number, nthRoot.CalculateNewtonNthRoot(nthRoot));
            ShowResults("The {0}th root of {1} is: {2}", exponent, number, nthRoot.CalculateNthRoot(nthRoot));
            CompareResults(nthRoot.CalculateNewtonNthRoot(nthRoot), nthRoot.CalculateNthRoot(nthRoot));
        }
    }
}