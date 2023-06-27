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

namespace WPFTutorial
{
    /// <summary>
    /// Interaction logic for ThirdMainWindow.xaml
    /// </summary>
    public partial class ThirdMainWindow : Window
    {
        public ThirdMainWindow()
        {
            InitializeComponent();
        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you agree", "Agreement",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                tbInfo.Text = "Agreed";
            }
            else
            {
                tbInfo.Text = "Not agreed";
            }
        }
    }
}
