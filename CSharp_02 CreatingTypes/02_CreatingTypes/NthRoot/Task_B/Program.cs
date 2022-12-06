using System;
using System.Collections.Generic;
using Converter;

namespace Task_B
{
    class Program
    {
        const int NumberLimit = 0;
        const string NonValidInput = "Invalid input";
        const string EqualityMessage = "Results are equal.";
        const string NonequalityMessage = "Results are unequal.";
        public static int InputInt(string displayMessage)
        {
            int intValue;
            Console.WriteLine(displayMessage);
            while (!(int.TryParse(Console.ReadLine(), out intValue)) && !(intValue > NumberLimit))
            {
                Console.WriteLine(NonValidInput);
            }
            return intValue;
        }
        public static void Compare(string result, string resultStandart)
        {
            string resultsEqualityMessage = result.Equals(resultStandart) ? EqualityMessage : NonequalityMessage;
        }
        static void Main(string[] args)
        {
            int inputValue = InputInt("Enter a non-negative integer:");
            List<string> results = new List<string>(new string[] { BaseConverter.ToBin(inputValue), BaseConverter.ToOct(inputValue), BaseConverter.ToHex(inputValue), BaseConverter.ToBase32(inputValue), BaseConverter.ToBase64(inputValue) });
            List<string> resultsStandard = new List<string>(new string[] { BaseConverter.ToBinStandard(inputValue), BaseConverter.ToOctStandard(inputValue), BaseConverter.ToHexStandard(inputValue), "There is no standard method for Base32.", BaseConverter.ToBase64Standard(inputValue) });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Our base conversion:\t \t \t \t Standard conversion:");
            for (int j = 0; j < resultsStandard.Count; j++)
            {
                Console.WriteLine("{0, -15} \t \t --> \t \t {1}", results[j], resultsStandard[j]);
                Compare(results[j], resultsStandard[j]);
            }
        }
    }

}
