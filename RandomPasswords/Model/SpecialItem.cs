namespace RandomPasswords.Model
{
    /// <summary>
    /// Contains special format item characters.
    /// </summary>
    public struct SpecialItem
    {
        public const char Word = 'w';
        public const char CapitalWord = 'W';
        public const char Symbol = '*';
        public const char Number = '0';
        public const char Seperator = 's';
        public const char Space = '‿';
        public const char Underscore = '_';
        public const char Any = '?';
        public static char[] AvailableItems = new char[] 
        { Word, CapitalWord, Symbol, Number, Seperator, Space, Underscore, Any };
    }
}