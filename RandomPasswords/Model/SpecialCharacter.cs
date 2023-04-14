using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomPasswords.Model
{
    public class SpecialCharacter : INotifyPropertyChanged
    {
        private char _character;
        private bool _isAvailable;
        private string _name;

        public char Character
        {
            get { return _character; }
            set
            {
                _character = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = value;
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