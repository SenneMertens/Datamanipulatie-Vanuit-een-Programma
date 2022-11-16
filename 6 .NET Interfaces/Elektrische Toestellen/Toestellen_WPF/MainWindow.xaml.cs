using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Toestellen_DAL;
using Toestellen_Models;

namespace Toestellen_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persoon persoon = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbProducten.ItemsSource = FileOperations.BestandInlezen($"Producten.txt");           

            persoon = new Persoon($"Senne Mertens", $"123-4567890-12");            
        }

        private void BtnBankrekeningAanmaken_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding;

            foutmelding = string.Empty;

            Bankrekening bankrekening = new Bankrekening(txtIbannummer.Text);

            if (persoon.Bankrekening == null)
            {
                if (bankrekening.IsGeldig())
                {
                    persoon.Bankrekening = bankrekening;

                    UpdateRekening();
                }
                else
                {
                    foutmelding += bankrekening.Error;

                    MessageBox.Show($"{foutmelding}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Deze persoon heeft al een bankrekening.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBankrekeningAfhalen_Click(object sender, RoutedEventArgs e)
        {
            if (persoon.Bankrekening != null)
            {
                if (double.TryParse(txtBedrag.Text, out double bedrag))
                {
                    if (persoon.Bankrekening.Afhalen(bedrag))
                    {
                        UpdateRekening();
                    }
                    else
                    {
                        MessageBox.Show($"Het saldo mag niet onder {persoon.Bankrekening.Minimum} komen.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Vul een geldig bedrag in.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Deze persoon heeft nog geen bankrekening.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }           
        }

        private void BtnBankrekeningStorten_Click(object sender, RoutedEventArgs e)
        {
            if (persoon.Bankrekening != null)
            {
                if (double.TryParse(txtBedrag.Text, out double bedrag))
                {
                    persoon.Bankrekening.Storten(bedrag);

                    UpdateRekening();
                }
                else
                {
                    MessageBox.Show($"Vul een geldig bedrag in.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Deze persoon heeft nog geen bankrekening.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void BtnProductKopen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProducten.SelectedItem is Product product)
            { 
                if (persoon.KoopProduct(product))
                {
                    UpdateRekening();

                    UpdateGekochteProducten();
                }
                else
                {
                    MessageBox.Show($"Uw krediet is ontoereikend.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Selecteer een product.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnProductNieuw_Click(object sender, RoutedEventArgs e)
        {
            Window toestelWindow = new ToestelWindow();

            toestelWindow.Show();
        }

        public void UpdateRekening()
        {
            txtBedrag.Text = string.Empty;
            txtIbannummer.Text = string.Empty;

            lblBankrekeningResultaat.Content = persoon.Bankrekening.ToString();
        }

        public void UpdateGekochteProducten()
        {     
            lblProductenGekocht.Content = persoon.ToString();
        }        
    }
}
