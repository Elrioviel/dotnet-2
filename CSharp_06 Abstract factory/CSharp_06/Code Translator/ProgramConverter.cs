namespace Code_Translator
{
    class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string VBToCSharp)
        {
            return "ProgramConverter: Converting from VB to CSharp...";
        }

        public string ConvertToVB(string CSharpToVB)
        {
            return "ProgramConverter: Converting from CSharp to VB...";
        }
    }
}
