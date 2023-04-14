using System.Windows;
using System.Windows.Input;

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

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void AboutCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AboutWindow aboutWindow = new();
            aboutWindow.ShowDialog();
        }
    }
}