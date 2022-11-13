using Printerbeheer_Models;
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

namespace Printerbeheer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PC _pc;

        private Printer _printer1;
        private Printer _printer2;
        private Printer _printer3;
        private Printer _printer4;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _pc = new PC();

            _printer1 = new Printer($"Printer1");
            _printer2 = new Printer($"Printer2");
            _printer3 = new Printer($"Printer3");
            _printer4 = new Printer($"Printer4");

            _pc.VoegPrinterToe(_printer1);
            _pc.VoegPrinterToe(_printer2);
            _pc.VoegPrinterToe(_printer3);
            _pc.VoegPrinterToe(_printer4);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            _pc.DrukAf();

            StelIn();
        }

        private void BtnResetPrinter1_Click(object sender, RoutedEventArgs e)
        {
            _printer1.Reset();

            StelIn();
        }

        private void BtnResetPrinter2_Click(object sender, RoutedEventArgs e)
        {
            _printer2.Reset();

            StelIn();
        }

        private void BtnResetPrinter3_Click(object sender, RoutedEventArgs e)
        {
            _printer3.Reset();

            StelIn();
        }

        private void BtnResetPrinter4_Click(object sender, RoutedEventArgs e)
        {
            _printer4.Reset();

            StelIn();
        }

        private void StelIn()
        {
            btnPrinter1.IsChecked = _printer1.Bezig;
            btnPrinter1.ToolTip = _printer1.ToString();
            btnPrinter2.IsChecked = _printer2.Bezig;
            btnPrinter2.ToolTip = _printer2.ToString();
            btnPrinter3.IsChecked = _printer3.Bezig;
            btnPrinter3.ToolTip = _printer3.ToString();
            btnPrinter4.IsChecked = _printer4.Bezig;
            btnPrinter4.ToolTip = _printer4.ToString();
        }
    }
}
