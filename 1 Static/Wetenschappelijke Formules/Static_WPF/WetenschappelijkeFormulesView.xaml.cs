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
    /// Interaction logic for WetenschappelijkeFormulesView.xaml
    /// </summary>
    public partial class WetenschappelijkeFormulesView : UserControl
    {
        public WetenschappelijkeFormulesView()
        {
            InitializeComponent();
        }

        private void BtnArbeidBerekenen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtArbeidKracht.Text, out double kracht) && double.TryParse(txtArbeidVerplaatsing.Text, out double verplaatsing))
            {
                lblArbeidResultaat.Content = $"Resultaat: {WetenschappelijkeFormules.Arbeid(kracht, verplaatsing).ToString("0.##")}.";

                txtArbeidKracht.Text = string.Empty;
                txtArbeidVerplaatsing.Text = string.Empty;
            }
            else
            {
                lblArbeidResultaat.Content = $"Vul 2 correcte waarden in.";
            }
        }

        private void BtnGravitatieBerekenen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtGravitatieHoogte.Text, out double hoogte) && double.TryParse(txtGravitatieMassa.Text, out double massa))
            {
                lblGravitatieResultaat.Content = $"Resultaat: {WetenschappelijkeFormules.GravitatiePotentieleEnergie(massa, hoogte).ToString("0.##")}.";

                txtGravitatieHoogte.Text = string.Empty;
                txtGravitatieMassa.Text = string.Empty;
            }
            else
            {
                lblGravitatieResultaat.Content = $"Vul 2 correcte waarden in.";
            }
        }

        private void BtnVermogenBerekenen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtVermogenArbeid.Text, out double arbeid) && int.TryParse(txtVermogenTijdsduur.Text, out int tijdsduur))
            {
                lblVermogenResultaat.Content = $"Resultaat: {WetenschappelijkeFormules.Vermogen(arbeid, tijdsduur).ToString("0.##")}.";

                txtVermogenArbeid.Text = string.Empty;
                txtVermogenTijdsduur.Text = string.Empty;
            }
            else
            {
                lblVermogenResultaat.Content = $"Vul 2 correcte waarden in.";
            }
        }

        private void BtnZwaartekrachtBerekenen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtZwaartekrachtMassa.Text, out double massa))
            {
                lblZwaartekrachtResultaat.Content = $"Resultaat: {WetenschappelijkeFormules.Zwaartekracht(massa).ToString("0.##")}.";

                txtZwaartekrachtMassa.Text = string.Empty;
            }
            else
            {
                lblZwaartekrachtResultaat.Content = $"Vul een correcte waarde in.";
            }
        }
    }
}
