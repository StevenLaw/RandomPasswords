namespace RandomPasswords.Model
{
    public struct SpecialItem
    {
        public const char Word = 'w';
        public const char Symbol = '*';
        public const char Number = '0';
        public const char Seperator = 's';
        public static char[] AvailableItems = new char[] { Word, Symbol, Number, Seperator };
    }
}