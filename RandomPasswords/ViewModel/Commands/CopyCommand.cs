using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RandomPasswords.ViewModel.Commands
{
    public class CopyCommand : ICommand
    {
        public RandomPasswordViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged 
        { 
            add 
            {
                CommandManager.RequerySuggested += value;
            } 
            remove 
            {
                CommandManager.RequerySuggested -= value;
            } 
        }

        public CopyCommand(RandomPasswordViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            if (VM.SelectedPasswords != null)
                return VM.SelectedPasswords.Count() > 0;
            return false;
        }

        public void Execute(object parameter)
        {
            if (VM.SelectedPasswords != null)
            {
                Clipboard.SetText(string.Join(VM.GetSeperator(), VM.SelectedPasswords));
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
