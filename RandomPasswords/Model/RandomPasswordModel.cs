﻿using RandomPasswords.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RandomPasswords.Model
{
    public class RandomPasswordModel : INotifyPropertyChanged
    {
        private int _numberOfPasswords = 10;
        private int _numberOfWords = 3;
        private int _minimumSeparators = 0;
        private int _maximiumSeparators = 1;
        private SeperatorsMode _separatorsMode;
        private string _specialFormat = "WsWsW";
        private const string _lettersAndNumbers = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// Gets or sets the number of passwords.
        /// </summary>
        /// <value>
        /// The number of passwords.
        /// </value>
        public int NumberOfPasswords
        {
            get { return _numberOfPasswords; }
            set
            {
                _numberOfPasswords = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number of words.
        /// </summary>
        /// <value>
        /// The number of words.
        /// </value>
        public int NumberOfWords
        {
            get { return _numberOfWords; }
            set
            {
                _numberOfWords = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the seperators mode.
        /// </summary>
        /// <value>
        /// The seperators mode.
        /// </value>
        public SeperatorsMode SeparatorsMode
        {
            get { return _separatorsMode; }
            set
            {
                _separatorsMode = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the minimum separators.
        /// </summary>
        /// <value>
        /// The minimum separators.
        /// </value>
        public int MinimumSeparators
        {
            get { return _minimumSeparators; }
            set
            {
                _minimumSeparators = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the maximium separators.
        /// </summary>
        /// <value>
        /// The maximium separators.
        /// </value>
        public int MaximiumSeparators
        {
            get { return _maximiumSeparators; }
            set
            {
                _maximiumSeparators = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the special format.
        /// </summary>
        /// <value>
        /// The special format.
        /// </value>
        public string SpecialFormat
        {
            get { return _specialFormat; }
            set
            {
                _specialFormat = new string(value.
                    ToArray().
                    Where(c => SpecialItem.AvailableItems.Contains(c)).
                    ToArray());
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the special characters.
        /// </summary>
        /// <value>
        /// The special characters.
        /// </value>
        public ObservableCollection<SpecialCharacter> SpecialCharacters { get; set; }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomPasswordModel"/> class.
        /// </summary>
        public RandomPasswordModel()
        {
            SpecialCharacters = new ObservableCollection<SpecialCharacter>(SpecialCharacterList.GetSpecialCharacters(SpecialCharacterList.Profiles.DefaultCharacters));
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Updates the character profile.
        /// </summary>
        /// <param name="profileName">Name of the profile.</param>
        public void UpdateCharacterProfile(string profileName)
        {
            char[] profile = profileName switch
            {
                ProfileTypes.All => SpecialCharacterList.Profiles.All,
                ProfileTypes.JustSpace => SpecialCharacterList.Profiles.JustSpace,
                ProfileTypes.None => SpecialCharacterList.Profiles.None,
                _ => SpecialCharacterList.Profiles.DefaultCharacters,
            };
            foreach (SpecialCharacter c in SpecialCharacters)
            {
                if (profile.Contains(c.Character))
                {
                    c.IsAvailable = true;
                }
                else
                {
                    c.IsAvailable = false;
                }
            }
        }

        /// <summary>
        /// Gets the passwords.
        /// </summary>
        /// <returns>
        /// the passwords.
        /// </returns>
        public string[] GetPasswords()
        {
            string[] passwords = new string[NumberOfPasswords];
            Random r = new();

            for (int i = 0; i < _numberOfPasswords; i++)
            {
                passwords[i] = GetPassword(r);
            }

            return passwords;
        }

        /// <summary>
        /// Gets the special passwords.
        /// </summary>
        /// <returns>
        /// the special passwords.
        /// </returns>
        public string[] GetSpecialPasswords()
        {
            string[] passwords = new string[NumberOfPasswords];
            Random r = new();

            for (int i = 0; i < _numberOfPasswords; i++)
            {
                passwords[i] = GetSpecialPassword(r);
            }

            return passwords;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>
        /// the password.
        /// </returns>
        public string GetPassword(Random r)
        {
            StringBuilder sb = new(GetWord(r, true));

            for (int i = 0; i < _numberOfWords - 1; i++)
            {
                sb.Append(GetSeparators(r));
                sb.Append(GetWord(r, true));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the special password.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>
        /// the special password.
        /// </returns>
        public string GetSpecialPassword(Random r)
        {
            StringBuilder sb = new();

            foreach (char item in _specialFormat)
            {
                switch (item)
                {
                    case SpecialItem.CapitalWord:
                        sb.Append(GetWord(r, isCapitalized: true));
                        break;

                    case SpecialItem.Number:
                        sb.Append(GetSeperator(r, SeperatorsMode.Numbers));
                        break;

                    case SpecialItem.Seperator:
                        sb.Append(GetSeperator(r, SeperatorsMode.NumbersAndSpecial));
                        break;

                    case SpecialItem.Symbol:
                        sb.Append(GetSeperator(r, SeperatorsMode.Special));
                        break;

                    case SpecialItem.Word:
                        sb.Append(GetWord(r));
                        break;

                    case SpecialItem.Space:
                        sb.Append(' ');
                        break;

                    case SpecialItem.Underscore:
                        sb.Append('_');
                        break;

                    case SpecialItem.Any:
                        sb.Append(GetAnyCharacter(r, SeperatorsMode.Special));
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the word.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="isCapitalized">if set to <c>true</c> [is capitalized].</param>
        /// <returns>
        /// the word.
        /// </returns>
        private static string GetWord(Random r, bool isCapitalized = false)
        {
            string tmp = Words.Items[r.Next(Words.Items.Length)];
            if (isCapitalized)
                return tmp.First().ToString().ToUpper() + tmp[1..];
            else return tmp;
        }

        /// <summary>
        /// Gets the separators.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>
        /// the separators.
        /// </returns>
        private string GetSeparators(Random r)
        {
            string tmp = string.Empty;
            int amount = r.Next(MinimumSeparators, MaximiumSeparators + 1);
            char[] characters = SpecialCharacterList.GetCharList(SpecialCharacters, _separatorsMode);

            for (int i = 0; i < amount; i++)
            {
                tmp += characters[r.Next(characters.Length)];
            }
            return tmp;
        }

        /// <summary>
        /// Gets the seperator.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>
        /// the seperator.
        /// </returns>
        private char GetSeperator(Random r, SeperatorsMode mode)
        {
            char[] characters = SpecialCharacterList.GetCharList(SpecialCharacters, mode);
            return characters[r.Next(characters.Length)];
        }

        /// <summary>
        /// Gets any character.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>
        /// the random character.
        /// </returns>
        private char GetAnyCharacter(Random r, SeperatorsMode mode)
        {
            var list = new List<char>();
            list.AddRange(_lettersAndNumbers.ToArray());
            list.AddRange(SpecialCharacterList.GetCharList(SpecialCharacters, mode));
            return list[r.Next(list.Count)];
        }
    }
}