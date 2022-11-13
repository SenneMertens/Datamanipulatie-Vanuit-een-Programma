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
using System.Windows.Threading;
using Benzinepomp_Models;

namespace Benzinepomp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tankmechanisme _tankmechanisme;
        private DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAantalLiter.Text, out int aantalLiter))
            {
                _tankmechanisme = new Tankmechanisme();

                _tankmechanisme.GevraagdAantal = aantalLiter;

                _tankmechanisme.Start();

                _dispatcherTimer.Start();
            }
            else
            {
                MessageBox.Show($"Vul een correct aantal liter benzine in.", $"Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnStandVanZaken_Click(object sender, RoutedEventArgs e)
        {
            lblStandVanZaken.Content = _tankmechanisme.StandVanZaken();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblStandVanZaken.Content = _tankmechanisme.StandVanZaken();
        }
    }
}
