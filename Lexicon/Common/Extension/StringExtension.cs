namespace Lexicon.Common.Extension
{
    internal class StringExtension
    {
        public string SafeFarsiStr(string input)
        {
            return input.Replace("ي", "ی").Replace("ك", "ک");
        }
    }
}