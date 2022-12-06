namespace Code_Translator
{
    interface IConvertible
    {
        string ConvertToCSharp(string VBToCSharp);
        string ConvertToVB(string CSharpToVB);
    }
}
