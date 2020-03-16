using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomPasswords.ViewModel.Commands
{
    public class GetSpecialPasswordsCommand : ICommand
    {
        /// <summary>
        /// Gets or sets the vm.
        /// </summary>
        /// <value>
        /// The vm.
        /// </value>
        public RandomPasswordViewModel VM { get; set; }
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSpecialPasswordsCommand"/> class.
        /// </summary>
        /// <param name="vm">The vm.</param>
        public GetSpecialPasswordsCommand(RandomPasswordViewModel vm)
        {
            VM = vm;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns>
        ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            VM.Passwords.Clear();
            string[] passwords = VM.RandomPassword.GetSpecialPasswords();
            foreach (string password in passwords)
            {
                VM.Passwords.Add(password);
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
