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

namespace PuntoDeVenta.Views
{
    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
        }

        #region BUSCADOR
        private void Buscando(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        #region CRUD PRODUCTO

        #region CREATE
        private void BtnCrearProducto_Click(object sender, RoutedEventArgs e)
        {
            CRUDProductos ventana = new CRUDProductos();
            this.FrameProductos.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region READ
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region UPDATE
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region DELETE
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #endregion
    }
}
