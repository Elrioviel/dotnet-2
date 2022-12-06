using System;
using System.Collections.Generic;
using PointProcessor;

namespace PointProcessorUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Processor.ProcessFiles(args);
            }
            else
            {
                Processor.ProcessConsole();
            }
        }
    }
}
