namespace Pokedex.Library.Utilities
{
    public static class StringCleaner
    {
        public static string RemoveEscapeSequences(string input)
        {
            const string space = " ";
            const string empty = "";

            return input
                .Replace("\n", space)
                .Replace("\f", empty)
                .Replace("\r", space)
                .Replace("\t", space);
        }   
    }
}
