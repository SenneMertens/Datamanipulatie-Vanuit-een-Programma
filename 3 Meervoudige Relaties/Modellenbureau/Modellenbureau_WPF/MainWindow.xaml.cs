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
using Modellenbureau_Models;

namespace Modellenbureau_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Modellenbureau> _modellenbureaus;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _modellenbureaus = new List<Modellenbureau>();

            lbModellenbureau.ItemsSource = _modellenbureaus;
        }

        private void BtnModellenbureauAanmaken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modellenbureau modellenbureau = new Modellenbureau(txtModellenbureauNaam.Text);

                if (!_modellenbureaus.Contains(modellenbureau))
                {
                    _modellenbureaus.Add(modellenbureau);

                    lbModellenbureau.Items.Refresh();

                    txtModellenbureauNaam.Text = string.Empty;
                }
                else
                {
                    throw new Exception($"Dit modellenbureau zit al in de lijst.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnToonSuperslankeModellen_Click(object sender, RoutedEventArgs e)
        {
            if (lbModellenbureau.SelectedItem is Modellenbureau modellenbureau)
            {
                MessageBox.Show($"{modellenbureau.DrukSlank()}", $"Superslankke Modellen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Selecteer een modellenbureau.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnModelToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidatieModel();

                if (lbModellenbureau.SelectedItem is Modellenbureau modellenbureau)
                {
                    modellenbureau.VoegToe(double.Parse(txtmodelLengte.Text), txtmodelNaam.Text, double.Parse(txtmodelPols.Text));
                }
                else
                {
                    MessageBox.Show($"Selecteer een modellenbureau.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ResetVeldenModel();
                lbModellenbureau.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public void ValidatieModel()
        {
            if (string.IsNullOrWhiteSpace(txtmodelNaam.Text))
            {
                throw new Exception($"Vul een naam in.");
            }
            if (!double.TryParse(txtmodelLengte.Text, out double lengte))
            {
                throw new Exception($"Vul een correcte lengte in.");
            }
            if (!double.TryParse(txtmodelPols.Text, out double pols))
            {
                throw new Exception($"Vul een correcte polsomtrek in.");
            }
        }

        public void ResetVeldenModel()
        {
            txtmodelNaam.Text = string.Empty;
            txtmodelLengte.Text = string.Empty;
            txtmodelPols.Text = string.Empty;
        }
    }
}
