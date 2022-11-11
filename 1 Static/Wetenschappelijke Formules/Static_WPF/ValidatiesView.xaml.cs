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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Static_Models;

namespace Static_WPF
{
    /// <summary>
    /// Interaction logic for ValidatiesView.xaml
    /// </summary>
    public partial class ValidatiesView : UserControl
    {
        public ValidatiesView()
        {
            InitializeComponent();
        }

        private void BtnRijksregisternummerControleren_Click(object sender, RoutedEventArgs e)
        {
            if (Validaties.IsRijksregisternummerGeldig(txtRijkregisternummer.Text))
            {
                lblRijksregisternummerResultaat.Content = $"{txtRijkregisternummer.Text} is een geldig rijksregisternummer.";

                txtRijkregisternummer.Text = string.Empty;
            }
            else
            {
                lblRijksregisternummerResultaat.Content = $"{txtRijkregisternummer.Text} is geen geldig rijksregisternummer.";
            }
        }
    }
}
