using RandomPasswords.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RandomPasswords.View.UserControls
{
    /// <summary>
    /// Interaction logic for CopyableListViewControl.xaml
    /// </summary>
    public partial class CopyableListViewControl : UserControl
    {
        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(CopyableListViewControl), new PropertyMetadata(null, SetItemsSource));

        private static void SetItemsSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CopyableListViewControl copyableListView)
            {
                copyableListView.lstMain.ItemsSource = e.NewValue as IEnumerable<string>;
            }
        }

        public IEnumerable<string> SelectedItems
        {
            get { return (IEnumerable<string>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IEnumerable<string>), typeof(CopyableListViewControl), new PropertyMetadata(new List<string>(), SetSelectedItems));

        private static void SetSelectedItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(SelectedItemsProperty, e.NewValue);
        }

        public CopyableListViewControl()
        {
            InitializeComponent();
        }

        private void LstMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is RandomPasswordViewModel vm)
            {
                List<string> list = new();
                foreach (string item in lstMain.SelectedItems)
                {
                    list.Add(item);
                }
                vm.SetSelectedPassword(list);
            }
        }
    }
}