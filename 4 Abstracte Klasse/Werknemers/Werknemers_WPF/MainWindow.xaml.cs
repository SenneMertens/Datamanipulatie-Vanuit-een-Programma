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
using Werknemers_Models;

namespace Werknemers_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Bedrijf> _lijstBedrijven;
        private Bedrijf _bedrijf;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _lijstBedrijven = new List<Bedrijf>();

            cmbBedrijven.ItemsSource = _lijstBedrijven;
            
            rbCommissiewerker.IsChecked = true;
        }

        private void BtnBedrijfAanmaken_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBedrijfsnaam.Text))
            {
                Bedrijf bedrijf = new Bedrijf(txtBedrijfsnaam.Text);

                if (!_lijstBedrijven.Contains(bedrijf))
                {
                    _lijstBedrijven.Add(bedrijf);

                    cmbBedrijven.Items.Refresh();

                    txtBedrijfsnaam.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Dit bedrijf zit al in de lijst.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Vul een bedrijfsnaam in.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RbCommissiewerker_Checked(object sender, RoutedEventArgs e)
        {
            txtCommissie.Visibility = Visibility.Visible;
        }

        private void RbStukWerker_Checked(object sender, RoutedEventArgs e)
        {
            txtCommissie.Visibility = Visibility.Collapsed;
        }

        private void RbUurwerker_Checked(object sender, RoutedEventArgs e)
        {
            txtCommissie.Visibility = Visibility.Collapsed;
        }

        private void BtnWerkenemerToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string validatie;

            validatie = ValidatieWerkenemer();

            if (string.IsNullOrWhiteSpace(validatie))
            {
                Werknemer werknemer;
                Bedrijf bedrijf;

                if (rbCommissiewerker.IsChecked == true) 
                {
                    werknemer = new Commissiewerker(double.Parse(txtLoon.Text), txtNaam.Text, txtVoornaam.Text, int.Parse(txtAantalStuksUren.Text), double.Parse(txtCommissie.Text));
                }
                else if (rbStukWerker.IsChecked == true)
                {
                    werknemer = new Stukwerker(double.Parse(txtLoon.Text), txtNaam.Text, txtVoornaam.Text, int.Parse(txtAantalStuksUren.Text));
                }
                else
                {
                    werknemer = new Uurwerker(double.Parse(txtLoon.Text), txtNaam.Text, txtVoornaam.Text, double.Parse(txtAantalStuksUren.Text));
                }

                if (werknemer.IsGeldig())
                {
                    bedrijf = cmbBedrijven.SelectedItem as Bedrijf;

                    if (bedrijf.AddWerknemer(werknemer))
                    {
                        ResetVeldenWerknemer();

                        lbWerknemers.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"Deze werknemer zit al in de lijst.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"{werknemer.Foutmeldingen}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"{validatie}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbBedrijven_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBedrijven.SelectedItem is Bedrijf bedrijf)
            {
                lbWerknemers.ItemsSource = bedrijf.Werknemers;
            }
        }

        private string ValidatieWerkenemer()
        {
            string foutmeldingen;

            foutmeldingen = string.Empty;

            if (!(cmbBedrijven.SelectedItem is Bedrijf))
            {
                foutmeldingen += $"Selecteer een bedrijf.{Environment.NewLine}";
            }
            if (string.IsNullOrWhiteSpace(txtNaam.Text))
            {
                foutmeldingen += $"Vul een naam in.{Environment.NewLine}";
            }
            if (string.IsNullOrWhiteSpace(txtVoornaam.Text))
            {
                foutmeldingen += $"Vul een voornaam in.{Environment.NewLine}";
            }
            if (!double.TryParse(txtLoon.Text, out double loon))
            {
                foutmeldingen += $"Vul een correct loon in.{Environment.NewLine}";
            }

            if (rbCommissiewerker.IsChecked == true)
            {
                if (!int.TryParse(txtAantalStuksUren.Text, out int uren))
                {
                    foutmeldingen += $"Vul een correct aantal uren in.{Environment.NewLine}";
                }
                if (!double.TryParse(txtCommissie.Text, out double commissie))
                {
                    foutmeldingen += $"Vul een correcte commissie in.{Environment.NewLine}";
                }
            }
            else if (rbStukWerker.IsChecked == true)
            {
                if (!int.TryParse(txtAantalStuksUren.Text, out int uren))
                {
                    foutmeldingen += $"Vul een correct aantal stuks in.{Environment.NewLine}";
                }
            }
            else if (rbUurwerker.IsChecked == true)
            {
                if (!int.TryParse(txtAantalStuksUren.Text, out int uren))
                {
                    foutmeldingen += $"Vul een correct aantal uren in.{Environment.NewLine}";
                }

            }            

            return foutmeldingen;
        }

        private void ResetVeldenWerknemer()
        {
            txtNaam.Text = string.Empty;
            txtVoornaam.Text = string.Empty;
            txtLoon.Text = string.Empty;
            txtAantalStuksUren.Text = string.Empty;
            
            if (rbCommissiewerker.IsChecked == true)
            {
                txtCommissie.Text = string.Empty;
            }
        }
    }
}
