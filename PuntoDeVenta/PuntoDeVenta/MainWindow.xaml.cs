using PuntoDeVenta.Views;
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

namespace PuntoDeVenta
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TBShow(object sender, RoutedEventArgs e)
        {
            this.GridContent.Opacity = 0.5;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            this.GridContent.Opacity = 1;
        }

        private void PreviewMouseLeftButtonDownBG(object sender, MouseButtonEventArgs e)
        {
            this.BtnShowHide.IsChecked = false;
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Usuarios_click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Usuarios();
        }
    }
}
