using RandomPasswords.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RandomPasswords.View
{
    /// <summary>
    /// Interaction logic for PasswordGeneratorWindow.xaml
    /// </summary>
    public partial class PasswordGeneratorWindow : Window
    {
        public PasswordGeneratorWindow()
        {
            InitializeComponent();
        }

        //private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    if (grdMain.DataContext is RandomPasswordViewModel vm)
        //    {
        //        List<string> passwords = new List<string>();
        //        foreach(string password in lstPasswords.SelectedItems)
        //        {
        //            passwords.Add(password);
        //        }
        //        Clipboard.SetText(string.Join(vm.GetSeperator(), passwords));
        //    }
        //}

        //private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = lstPasswords.SelectedItems.Count > 0;
        //}

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
