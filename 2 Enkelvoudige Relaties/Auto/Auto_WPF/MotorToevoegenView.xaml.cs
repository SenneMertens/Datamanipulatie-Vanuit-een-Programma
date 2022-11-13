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
    /// Interaction logic for MotorToevoegenView.xaml
    /// </summary>
    public partial class MotorToevoegenView : UserControl
    {
        private List<Motor> _lijstMotors;

        public MotorToevoegenView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _lijstMotors = FileOperations.LeesMotor($"Motors.txt");

            lbMotors.ItemsSource = _lijstMotors;
        }

        private void BtnMotorToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GegevensControle();

                Motor motor = new Motor(int.Parse(txtCilinderinhoud.Text), int.Parse(txtPK.Text));

                if (!_lijstMotors.Contains(motor))
                {
                    FileOperations.SchrijfMotor($"Motors.txt", motor);

                    _lijstMotors = FileOperations.LeesMotor($"Motors.txt");
                    lbMotors.ItemsSource = _lijstMotors;

                    ResetVelden();
                }
                else
                {
                    throw new Exception($"Deze motor zit al in de lijst.");
                }
            }
            catch (Exception ex)
            {
                lblFoutmeldingen.Content = $"{ex.Message}";
            }
        }
        
        private void GegevensControle()
        {
            if (!int.TryParse(txtCilinderinhoud.Text, out int cilinderinhoud))
            {
                throw new Exception($"Vul een correcte cilinderinhoud in.");
            }
            if (!int.TryParse(txtPK.Text, out int pk))
            {
                throw new Exception($"Vul een correcte hoeveelheid pk in.");
            }
        }

        private void ResetVelden()
        {
            txtCilinderinhoud.Text = string.Empty;
            txtPK.Text = string.Empty;
        }
    }
}
