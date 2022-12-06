namespace Code_Translator
{
    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string stringToCheck, string language)
        {
            return true;
        }

        public new string ConvertToCSharp(string VBToCSharp)
        {
            return "ProgramHelper: Converting from VB to CSharp...";
        }

        public new string ConvertToVB(string CSharpToVB)
        {
            return "ProgramHelper: Converting from CSharp to VB...";
        }
    }
}
