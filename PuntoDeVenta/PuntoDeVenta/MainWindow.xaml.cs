using PuntoDeVenta.src;
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

            string tema = Properties.Settings.Default.Tema;

            this.Temas.Items.Add("Green");
            this.Temas.Items.Add("Dark");
            this.Temas.Items.Add("Red");

            if(tema != null)
            {
                if(tema == "Green")
                {
                    this.Temas.SelectedIndex = 0;
                }
                else if(tema == "Dark")
                {
                    this.Temas.SelectedIndex = 1;
                }
                else if(tema == "Red")
                {
                    this.Temas.SelectedIndex = 2;
                }
            }
            this.CargarTema();
        }


        private void TBShow(object sender, RoutedEventArgs e)
        {
            this.GridContent.Opacity = 0.8;
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
            //this.Close();
            Application.Current.Shutdown();
        }

        private void Usuarios_click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Usuarios();
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if(e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        this.DragMove();
        //    }
        //}

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Productos();
        }

        private void Dashboard(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Dashboard();
        }

        private void POS(object sender, RoutedEventArgs e)
        {
            this.DataContext = new POS();
        }

        private void MiCuenta(object sender, RoutedEventArgs e)
        {
            MiCuenta miCuenta = new MiCuenta();
            miCuenta.ShowDialog();
        }

        private void AcercaDe(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }

        #region MOVER VENTANA

        private void Mover(Border header)
        {
            var restaurar = false;

            header.MouseLeftButtonDown += (s, e) =>
            {
                if (e.ClickCount == 2)
                {
                    if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
                    {
                        this.CambiarEstado();
                    }
                }
                else
                {
                    if (WindowState == WindowState.Maximized)
                    {
                        restaurar = true;
                    }
                    this.DragMove();
                }
            };

            header.MouseLeftButtonUp += (s, e) =>
            {
                restaurar = false;
            };

            header.MouseMove += (s, e) =>
            {
                if (restaurar)
                {
                    try
                    {
                        restaurar = false;
                        var mouseX = e.GetPosition(this).X;
                        var width = RestoreBounds.Width;
                        var x = mouseX - width / 2;

                        if (x < 0)
                        {
                            x = 0;
                        }
                        else if (x + width > SystemParameters.PrimaryScreenWidth)
                        {
                            x = SystemParameters.PrimaryScreenWidth - width;
                        }

                        this.WindowState = WindowState.Normal;
                        this.Left = x;
                        this.Top = 0;
                        this.DragMove();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
        }

        private void CambiarEstado()
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    {
                        this.WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        this.WindowState = WindowState.Normal;
                        break;
                    }
            }
        }

        private void RestaurarVentana(object sender, RoutedEventArgs e)
        {
            this.Mover(sender as Border);
        }
        #endregion

        private void CambiarTema(object sender, SelectionChangedEventArgs e)
        {
            if(this.Temas.SelectedIndex == 0)
            {
                Properties.Settings.Default.Tema = "Green";
            }
            else if(this.Temas.SelectedIndex == 1)
            {
                Properties.Settings.Default.Tema = "Dark";
            }
            else if(this.Temas.SelectedIndex == 2)
            {
                Properties.Settings.Default.Tema = "Red";
            }
            Properties.Settings.Default.Save();
            this.CargarTema();
        }

        public void CargarTema()
        {
            Temas temas = new Temas();
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(temas.CargarTema());
        }
    }
}
