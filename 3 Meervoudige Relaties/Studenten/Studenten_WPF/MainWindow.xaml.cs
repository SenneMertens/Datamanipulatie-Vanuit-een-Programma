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
using Studenten_Models;

namespace Studenten_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Klas klas = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbStudent.IsChecked = true;
        }

        private void BtnKlasAanmaken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtKlasnaam.Text))
                {
                    klas = new Klas(txtKlasnaam.Text);

                    ToonGegevens();

                    txtKlasnaam.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }           
        }

        private void RbStudent_Checked(object sender, RoutedEventArgs e)
        {
            txtKotadres.Visibility = Visibility.Collapsed;
            txtKotbaas.Visibility = Visibility.Collapsed;
        }

        private void RbKotstudent_Checked(object sender, RoutedEventArgs e)
        {
            txtKotadres.Visibility = Visibility.Visible;
            txtKotbaas.Visibility = Visibility.Visible;
        }

        private void BtnStudentToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidatieStudent();

                Student student;           

                if (rbStudent.IsChecked == true)
                {
                    student = new Student(txtStudentnaam.Text, txtStudentnummer.Text);
                }
                else
                {
                    student = new Kotstudent(txtStudentnummer.Text, txtStudentnaam.Text, txtKotadres.Text, txtKotbaas.Text);
                }
                
                klas.VoegStudentToe(student);

                ResetVeldenStudent();

                ToonGegevens();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CbDetails_Click(object sender, RoutedEventArgs e)
        {
            ToonGegevens();
        }

        private void ValidatieStudent()
        {
            if (klas == null)
            {
                throw new Exception($"Maak eerst een klas aan.");
            }
            if (string.IsNullOrWhiteSpace(txtStudentnummer.Text))
            {
                throw new Exception($"Vul een correct studentnummer in.");
            }
            if (string.IsNullOrWhiteSpace(txtStudentnaam.Text))
            {
                throw new Exception($"Vul een naam in.");
            }
            if (rbKotstudent.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(txtKotadres.Text))
                {
                    throw new Exception($"Vul een correct adres in");
                }
                if (string.IsNullOrWhiteSpace(txtKotbaas.Text))
                {
                    throw new Exception($"Vul een correcte kotbaas in");
                }
            }
        }

        private void ResetVeldenStudent()
        {
            txtStudentnaam.Text = string.Empty;
            txtStudentnummer.Text = string.Empty;
            txtKotadres.Text = string.Empty;
            txtKotbaas.Text = string.Empty;
        }

        private void ToonGegevens()
        {
            string resultaat;

            resultaat = string.Empty;

            if (cbDetails.IsChecked == true)
            {
                resultaat = klas.MaakUitgebreideLijst();
            }
            else
            {
                resultaat = klas.MaakLijst();
            }

            txtKlas.Text = resultaat;
        }
    }
}
