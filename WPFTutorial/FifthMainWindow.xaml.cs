using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFTutorial
{
    /// <summary>
    /// Interaction logic for FifthMainWindow.xaml
    /// </summary>
    public partial class FifthMainWindow : Window
    {
        private ObservableCollection<string> entries;

        public ObservableCollection<string> Entries
        {
            get { return entries; }
            set { entries = value; }
        }


        public FifthMainWindow()
        {
            DataContext = this;
            entries = new ObservableCollection<string>();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //lvEntries.Items.Add(txtEntries.Text);
            //txtEntries.Clear();
            Entries.Add(txtEntries.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //int index = lvEntries.SelectedIndex;
            //object item = lvEntries.SelectedItem;
            //var items = lvEntries.SelectedItems;
            //lvEntries.Items.RemoveAt(index);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //lvEntries.Items.Clear();
        }
    }
}
