using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswords.Model
{
    public class SpecialCharacter : INotifyPropertyChanged
    {
        private char character;
        private bool isAvailable;
        private string name;

        public char Character
        {
            get { return character; }
            set
            {
                character = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }


        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                isAvailable = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
