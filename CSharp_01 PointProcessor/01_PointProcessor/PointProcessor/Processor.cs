using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PointProcessor
{
    public class Processor
    {
        public static void ProcessFiles(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                if (File.Exists(filename))
                {
                    Console.WriteLine("Processing the file: {0}", filename);
                    ProcessLines(File.ReadAllLines(filename).ToList());
                }
                else
                {
                    Console.WriteLine("{0} doesn't exist", filename);
                }
            }
        }

        public static void ProcessConsole()
        {
            List<string> coordinatesFromConsole = new List<string>();
            Console.WriteLine("Please enter X and Y values:");
            string userInput = Console.ReadLine();
            while ((userInput = Console.ReadLine()) != string.Empty)
            {
                coordinatesFromConsole.Add(userInput);
            }
            ProcessLines(coordinatesFromConsole);
        }
        public static string ProcessLine(string line)
        {
            if (Parser.TryParsePoint(line, out Point point))
            {
                return Formatter.Format(point);
            }
            return null;
        }
        public static void ProcessLines(List<string> lines)
        {
            foreach (var line in lines)
            {
                var result = ProcessLine(line);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
