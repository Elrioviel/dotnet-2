namespace Code_Translator
{
    interface ICodeChecker
    {
        bool CheckCodeSyntax(string stringToCheck, string language);
    }
}
