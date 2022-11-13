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
using Domotica_Models;

namespace Domotica_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PLC _domoticasysteem;

        private Lichten _keukenlichten;
        private Lichten _livinglichten;
        private Verwarming _verwarming;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _keukenlichten= new Lichten();
            _livinglichten= new Lichten();
            _verwarming= new Verwarming();

            _domoticasysteem = new PLC(_keukenlichten, _livinglichten, _verwarming);
        }

        private void BtnKeukenlicht_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.Keukenlichten.Power = !_domoticasysteem.Keukenlichten.Power;

            btnKeukenlicht.IsChecked = _domoticasysteem.Keukenlichten.Power;
        }

        private void BtnLivinglicht_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.Livinglichten.Power = !_domoticasysteem.Livinglichten.Power;

            btnLivinglicht.IsChecked = _domoticasysteem.Livinglichten.Power;
        }

        private void BtnVerwarmingPlus_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.Verwarming.Graden += 1;

            txtVerwarmingTemperatuur.Text = _domoticasysteem.Verwarming.Graden.ToString();
        }

        private void BtnVerwarmingMin_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.Verwarming.Graden -= 1;

            txtVerwarmingTemperatuur.Text = _domoticasysteem.Verwarming.Graden.ToString();
        }

        private void BtnVerwarming_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.Verwarming.Power = !_domoticasysteem.Verwarming.Power;

            btnVerwarming.IsChecked = _domoticasysteem.Verwarming.Power;
        }

        private void BtnKeukenlichtAan_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.DoeKeukenlichtenAan();

            btnKeukenlicht.IsChecked = _domoticasysteem.Keukenlichten.Power;
        }

        private void BtnKeukenlichtUit_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.DoeKeukenlichtenUit();

            btnKeukenlicht.IsChecked = _domoticasysteem.Keukenlichten.Power;
        }

        private void BtnLivinglichtAan_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.DoeLivinglichtenAan();

            btnLivinglicht.IsChecked = _domoticasysteem.Livinglichten.Power;
        }

        private void BtnLivinglichtUit_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.DoeLivinglichtenUit();

            btnLivinglicht.IsChecked = _domoticasysteem.Livinglichten.Power;
        }

        private void BtnVerwarmingAanwezig_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.ZetVerwarmingInAanwezigStand();

            txtVerwarmingTemperatuur.Text = _domoticasysteem.Verwarming.Graden.ToString();
        }

        private void BtnVerwarmingAfwezig_Click(object sender, RoutedEventArgs e)
        {
            _domoticasysteem.ZetVerwarmingInAfwezigStand();

            txtVerwarmingTemperatuur.Text = _domoticasysteem.Verwarming.Graden.ToString();
        }

        private void BtnPasTemperatuurAan_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtAantalGraden.Text, out double graden))
            {
                _domoticasysteem.PasTemperatuurAan(graden);

                txtVerwarmingTemperatuur.Text = _domoticasysteem.Verwarming.Graden.ToString();

                txtAantalGraden.Text = string.Empty;
            }
        }       
    }
}
