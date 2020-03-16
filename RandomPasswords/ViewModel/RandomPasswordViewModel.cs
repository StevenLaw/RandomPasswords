using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RandomPasswords.Model;
using RandomPasswords.ViewModel.Commands;

namespace RandomPasswords.ViewModel
{
	public class RandomPasswordViewModel : INotifyPropertyChanged
    {
		private string seperator = "\n";
		private string selectedProfile = ProfileTypes.Default;
		public string Seperator
		{
			get 
			{
				if (seperator == "\n")
					return "\\n";
				return seperator; 
			}
			set 
			{
				if (value == "\\n")
					seperator = "\n";
				else
					seperator = value;
				NotifyPropertyChanged();
			}
		}

		public string SelectedProfile
		{
			get { return selectedProfile; }
			set
			{
				selectedProfile = value;
				NotifyPropertyChanged();
			}
		}

		public RandomPasswordModel RandomPassword { get; set; } = new RandomPasswordModel();

		public ObservableCollection<string> Passwords { get; set; } = new ObservableCollection<string>();

		public ObservableCollection<string> SelectedPasswords { get; set; } = new ObservableCollection<string>();

		public GetPasswordsCommand GetPasswordsCommand { get; set; }
		public CopyCommand CopyCommand { get; set; }
		public SetProfileCommand SetProfileCommand { get; set; }
		public AddSpecialFormatItemCommand AddSpecialFormatItemCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public RandomPasswordViewModel()
		{
			GetPasswordsCommand = new GetPasswordsCommand(this);
			CopyCommand = new CopyCommand(this);
			SetProfileCommand = new SetProfileCommand(this);
			AddSpecialFormatItemCommand = new AddSpecialFormatItemCommand(this);
		}
		public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (propertyName != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void SetSelectedPassword(IEnumerable<string> selected)
		{
			SelectedPasswords.Clear();
			foreach (string password in selected)
			{
				SelectedPasswords.Add(password);
			}
			CopyCommand.RaiseCanExecuteChanged();
		}

		public string GetSeperator()
		{
			return seperator;
		}

		public void SetSelectedProfile(string profile)
		{
			SelectedProfile = profile;
			RandomPassword.UpdateCharacterProfile(profile);
		}
	}
}
