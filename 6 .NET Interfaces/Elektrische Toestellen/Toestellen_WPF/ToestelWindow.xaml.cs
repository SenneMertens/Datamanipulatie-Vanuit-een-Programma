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
using Toestellen_DAL;
using Toestellen_Models;

namespace Toestellen_WPF
{
    /// <summary>
    /// Interaction logic for ToestelWindow.xaml
    /// </summary>
    public partial class ToestelWindow : Window
    {
        private List<Product> _lijstProducten;

        public ToestelWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _lijstProducten = FileOperations.BestandInlezen($"Producten.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBoekToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding;
            Boek boek;

            foutmelding = ValidatieBoek();

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                boek = new Boek(txtProductBeschrijving.Text, txtProductCode.Text, double.Parse(txtProductPrijs.Text), txtBoekAuteur.Text);

                if (boek.IsGeldig())
                {
                    if (!_lijstProducten.Contains(boek))
                    {
                        FileOperations.VoegProductToe(boek);

                        _lijstProducten = FileOperations.BestandInlezen($"Producten.txt");

                        ResetVeldenProduct();
                    }
                    else
                    {
                        MessageBox.Show($"Dit product bestaat al.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"{boek.Error}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnTelevisieToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding;
            Televisie televisie;

            foutmelding = ValidatieTelevisie();

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                televisie = new Televisie(txtProductBeschrijving.Text, txtProductCode.Text, double.Parse(txtProductPrijs.Text), txtProductMerk.Text, txtProductType.Text, int.Parse(txtTelevisieBeeldgrootte.Text), int.Parse(txtTelevisieHerz.Text));

                if (televisie.IsGeldig())
                {
                    if (!_lijstProducten.Contains(televisie))
                    {
                        FileOperations.VoegProductToe(televisie);

                        _lijstProducten = FileOperations.BestandInlezen($"Producten.txt");

                        ResetVeldenProduct();
                    }
                    else
                    {
                        MessageBox.Show($"Dit product bestaat al.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"{televisie.Error}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnWarmwaterkokerToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding;
            Warmwaterkoker warmwaterkoker;

            foutmelding = ValidatieWarmwaterkoker();

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                warmwaterkoker = new Warmwaterkoker(txtProductBeschrijving.Text, txtProductCode.Text, double.Parse(txtProductPrijs.Text), txtProductMerk.Text, txtProductType.Text, double.Parse(txtWarmwaterkokerInhoud.Text));

                if (warmwaterkoker.IsGeldig())
                {
                    if (!_lijstProducten.Contains(warmwaterkoker))
                    {
                        FileOperations.VoegProductToe(warmwaterkoker);

                        _lijstProducten = FileOperations.BestandInlezen($"Producten.txt");

                        ResetVeldenProduct();
                    }
                    else
                    {
                        MessageBox.Show($"Dit product bestaat al.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"{warmwaterkoker.Error}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string ValidatieBoek()
        {
            string foutmelding;

            foutmelding = string.Empty;

            if (!double.TryParse(txtProductPrijs.Text, out double prijs))
            {
                foutmelding += $"Vul een geldige prijs in.{Environment.NewLine}";
            }

            return foutmelding;
        }

        private string ValidatieTelevisie()
        {
            string foutmelding;

            foutmelding = string.Empty;

            if (!double.TryParse(txtProductPrijs.Text, out double prijs))
            {
                foutmelding += $"Vul een geldige prijs in.{Environment.NewLine}";
            }
            if (!int.TryParse(txtTelevisieBeeldgrootte.Text, out int beeldgrootte))
            {
                foutmelding += $"Vul een geldige beeldgrootte in.{Environment.NewLine}";
            }
            if (!int.TryParse(txtTelevisieHerz.Text, out int herz))
            {
                foutmelding += $"Vul een geldig aantal herz in.{Environment.NewLine}";
            }

            return foutmelding;
        }

        private string ValidatieWarmwaterkoker()
        {
            string foutmelding;

            foutmelding = string.Empty;

            if (!double.TryParse(txtProductPrijs.Text, out double prijs))
            {
                foutmelding += $"Vul een geldige prijs in.{Environment.NewLine}";
            }
            if (!double.TryParse(txtWarmwaterkokerInhoud.Text, out double inhoud))
            {
                foutmelding += $"Vul een geldige beeldgrootte in.{Environment.NewLine}";
            }

            return foutmelding;
        }

        private void ResetVeldenProduct()
        {
            txtBoekAuteur.Text = string.Empty;
            txtProductBeschrijving.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtProductPrijs.Text = string.Empty;           
            txtProductMerk.Text = string.Empty;
            txtProductType.Text = string.Empty;
            txtTelevisieBeeldgrootte.Text = string.Empty;
            txtTelevisieHerz.Text = string.Empty;
            txtWarmwaterkokerInhoud.Text = string.Empty;
        }
    }
}
