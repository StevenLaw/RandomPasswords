using System.Collections.Generic;
using System.Linq;

namespace RandomPasswords.Model.Data
{
    public static class SpecialCharacterList
    {
        /// <summary>
        /// The character names
        /// </summary>
        public static readonly Dictionary<char, string> CharacterNames = new()
        {
            {' ', "Space"},
            {'!', "Exclamation"},
            {'”', "Double quote"},
            {'#', "Number sign (hash)"},
            {'$', "Dollar sign"},
            {'%', "Percent"},
            {'&', "Ampersand"},
            {'’', "Single quote"},
            {'(', "Left parenthesis"},
            {')', "Right parenthesis"},
            {'*', "Asterisk"},
            {'+', "Plus"},
            {',', "Comma"},
            {'-', "Minus"},
            {'.', "Full stop"},
            {'/', "Slash"},
            {':', "Colon"},
            {';', "Semicolon"},
            {'<', "Less than"},
            {'=', "Equal sign"},
            {'>', "Greater than"},
            {'?', "Question mark"},
            {'@', "At sign"},
            {'[', "Left bracket"},
            {'\\', "Backslash"},
            {']', "Right bracket"},
            {'^', "Caret"},
            {'_', "Underscore"},
            {'`', "Grave accent (backtick)"},
            {'{', "Left brace"},
            {'|', "Vertical bar"},
            {'}', "Right brace"},
            {'~', "Tilde"}
        };

        /// <summary>
        /// Preset special character profiles
        /// </summary>
        public readonly struct Profiles
        {
            public static readonly char[] All = new char[]
            {
                ' ','!','”','#','$','%','&','’','(',')','*','+',',','-','.','/',':',';','<','=','>','?','@','[','\\',']','^','_','`','{','|','}','~'
            };

            public static readonly char[] DefaultCharacters = new char[]
            {
                ' ', '!', '#', '$', '%', '&', '^', '*', '-', '_', '=', '+', ',', '.', '?', '~', ';', ':'
            };

            public static readonly char[] JustSpace = new char[] { ' ' };
            public static readonly char[] None = System.Array.Empty<char>();
        }

        /// <summary>
        /// Gets the special characters.
        /// </summary>
        /// <param name="allowedCharacters">The allowed characters.</param>
        /// <returns>
        /// the special characters.
        /// </returns>
        public static IEnumerable<SpecialCharacter> GetSpecialCharacters(IEnumerable<char> allowedCharacters)
        {
            List<SpecialCharacter> list = new();

            foreach (KeyValuePair<char, string> item in CharacterNames)
            {
                list.Add(new SpecialCharacter
                {
                    Character = item.Key,
                    IsAvailable = allowedCharacters.Contains(item.Key),
                    Name = item.Value
                });
            }

            return list;
        }

        /// <summary>
        /// Gets the character list.
        /// </summary>
        /// <param name="specialCharacters">The special characters.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>
        /// the character list.
        /// </returns>
        public static char[] GetCharList(IEnumerable<SpecialCharacter> specialCharacters, SeperatorsMode mode)
        {
            List<char> list = new();
            if (mode == SeperatorsMode.Numbers || mode == SeperatorsMode.NumbersAndSpecial)
                list.AddRange(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            if (mode == SeperatorsMode.NumbersAndSpecial || mode == SeperatorsMode.Special)
                list.AddRange(specialCharacters.Where(c => c.IsAvailable).Select(c => c.Character));

            return list.ToArray();
        }
    }
}