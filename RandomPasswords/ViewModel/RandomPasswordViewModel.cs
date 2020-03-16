using RandomPasswords.Model;
using RandomPasswords.ViewModel.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomPasswords.ViewModel
{
	public class RandomPasswordViewModel : INotifyPropertyChanged
    {
		private string separator = "\n";
		private string selectedProfile = ProfileTypes.Default;

		/// <summary>
		/// Gets or sets the seperator.
		/// </summary>
		/// <value>
		/// The seperator.
		/// </value>
		public string Separator
		{
			get 
			{
				if (separator == "\n")
					return "\\n";
				return separator; 
			}
			set 
			{
				if (value == "\\n")
					separator = "\n";
				else
					separator = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the selected profile.
		/// </summary>
		/// <value>
		/// The selected profile.
		/// </value>
		public string SelectedProfile
		{
			get { return selectedProfile; }
			set
			{
				selectedProfile = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the random password.
		/// </summary>
		/// <value>
		/// The random password.
		/// </value>
		public RandomPasswordModel RandomPassword { get; set; } = new RandomPasswordModel();

		/// <summary>
		/// Gets or sets the passwords.
		/// </summary>
		/// <value>
		/// The passwords.
		/// </value>
		public ObservableCollection<string> Passwords { get; set; } = new ObservableCollection<string>();

		/// <summary>
		/// Gets or sets the selected passwords.
		/// </summary>
		/// <value>
		/// The selected passwords.
		/// </value>
		public ObservableCollection<string> SelectedPasswords { get; set; } = new ObservableCollection<string>();

		/// <summary>
		/// Gets or sets the get passwords command.
		/// </summary>
		/// <value>
		/// The get passwords command.
		/// </value>
		public GetPasswordsCommand GetPasswordsCommand { get; set; }
		/// <summary>
		/// Gets or sets the copy command.
		/// </summary>
		/// <value>
		/// The copy command.
		/// </value>
		public CopyCommand CopyCommand { get; set; }
		/// <summary>
		/// Gets or sets the set profile command.
		/// </summary>
		/// <value>
		/// The set profile command.
		/// </value>
		public SetProfileCommand SetProfileCommand { get; set; }
		/// <summary>
		/// Gets or sets the add special format item command.
		/// </summary>
		/// <value>
		/// The add special format item command.
		/// </value>
		public AddSpecialFormatItemCommand AddSpecialFormatItemCommand { get; set; }
		/// <summary>
		/// Gets or sets the clear special format command.
		/// </summary>
		/// <value>
		/// The clear special format command.
		/// </value>
		public ClearSpecialFormatCommand ClearSpecialFormatCommand { get; set; }
		public GetSpecialPasswordsCommand GetSpecialPasswordsCommand { get; set; }

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Initializes a new instance of the <see cref="RandomPasswordViewModel"/> class.
		/// </summary>
		public RandomPasswordViewModel()
		{
			GetPasswordsCommand = new GetPasswordsCommand(this);
			CopyCommand = new CopyCommand(this);
			SetProfileCommand = new SetProfileCommand(this);
			AddSpecialFormatItemCommand = new AddSpecialFormatItemCommand(this);
			ClearSpecialFormatCommand = new ClearSpecialFormatCommand(this);
			GetSpecialPasswordsCommand = new GetSpecialPasswordsCommand(this);
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
		/// Sets the selected password.
		/// </summary>
		/// <param name="selected">The selected.</param>
		public void SetSelectedPassword(IEnumerable<string> selected)
		{
			SelectedPasswords.Clear();
			foreach (string password in selected)
			{
				SelectedPasswords.Add(password);
			}
			CopyCommand.RaiseCanExecuteChanged();
		}

		/// <summary>
		/// Gets the seperator.
		/// </summary>
		/// <returns>
		/// the seperator.
		/// </returns>
		public string GetSeperator()
		{
			return separator;
		}

		/// <summary>
		/// Sets the selected profile.
		/// </summary>
		/// <param name="profile">The profile.</param>
		public void SetSelectedProfile(string profile)
		{
			SelectedProfile = profile;
			RandomPassword.UpdateCharacterProfile(profile);
		}
	}
}
