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
using Auto_DAL;
using Auto_Models;

namespace Auto_WPF
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private List<string> _lijstMerken;
        private List<Motor> _lijstMotors;
        public List<Auto> _lijstAutos = new List<Auto>();

        public HomeView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _lijstMerken = FileOperations.LeesMerken($"Merken.txt");
            _lijstMotors = FileOperations.LeesMotor($"Motors.txt");
            
            cmbMerken.ItemsSource= _lijstMerken;
            cmbMotors.ItemsSource = _lijstMotors;

            lbAutos.ItemsSource = _lijstAutos;
        }

        private void BtnAutoToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GegevensControle();

                Auto auto = new Auto(txtChassisnummer.Text, cmbMerken.SelectedItem as string, cmbMotors.SelectedItem as Motor);

                if (!_lijstAutos.Contains(auto))
                {
                    _lijstAutos.Add(auto);

                    lbAutos.Items.Refresh();

                    ResetVelden();
                }
                else
                {
                    throw new Exception($"Deze auto zit al in de lijst.");
                }
            }
            catch(Exception ex)
            {
                lblFoutmeldingen.Content = $"{ex.Message}";
            }
        }

        private void GegevensControle()
        {
            if (string.IsNullOrWhiteSpace(txtChassisnummer.Text))
            {
                throw new Exception($"Vul een geldig chassisnummer in.");
            }
            if (!(cmbMerken.SelectedItem is string))
            {
                throw new Exception($"Selecteer een merk.");
            }
            if (!(cmbMotors.SelectedItem is Motor))
            {
                throw new Exception($"Selecteer een motor.");
            }
        }
        
        private void ResetVelden()
        {
            txtChassisnummer.Text = string.Empty;
            cmbMerken.SelectedIndex = -1;
            cmbMotors.SelectedIndex = -1;
        }
    }
}
