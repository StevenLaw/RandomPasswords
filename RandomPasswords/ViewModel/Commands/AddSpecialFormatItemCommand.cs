using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomPasswords.ViewModel.Commands
{
    public class AddSpecialFormatItemCommand : ICommand
    {
        public RandomPasswordViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public AddSpecialFormatItemCommand(RandomPasswordViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string item)
            {
                VM.RandomPassword.SpecialFormat += item;
            }
        }
    }
}
