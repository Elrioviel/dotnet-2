using System;

namespace Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            const string stringToTranslate = "Hello world";
            const string languageToTranslate = "CSharp";

            IConvertible[] programConverterArray = new IConvertible[2];
            programConverterArray[0] = new ProgramConverter();
            programConverterArray[1] = new ProgramHelper();
            foreach (var element in programConverterArray)
            {
                if (element is ICodeChecker)
                {
                    ICodeChecker codeToCheck = element as ProgramHelper;
                    if (codeToCheck.CheckCodeSyntax(stringToTranslate, languageToTranslate))
                    {
                        Console.WriteLine(element.ConvertToCSharp(stringToTranslate));
                    }
                    else
                    {
                        Console.WriteLine(element.ConvertToVB(stringToTranslate));
                    }
                }
                else
                {
                    IConvertible codeToConvert = element as ProgramConverter;
                    Console.WriteLine(codeToConvert.ConvertToCSharp(stringToTranslate));
                    Console.WriteLine(codeToConvert.ConvertToVB(stringToTranslate));
                }
            }
        }
    }
}
