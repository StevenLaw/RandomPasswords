using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomPasswords.ViewModel.Commands
{
    public class GetPasswordsCommand : ICommand
    {
        public RandomPasswordViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public GetPasswordsCommand(RandomPasswordViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Passwords.Clear();
            string[] passwords = VM.RandomPassword.GetPasswords();
            foreach(string password in passwords)
            {
                VM.Passwords.Add(password);
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
