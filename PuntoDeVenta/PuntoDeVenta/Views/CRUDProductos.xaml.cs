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
    /// <summary>
    /// Lógica de interacción para CRUDProductos.xaml
    /// </summary>
    public partial class CRUDProductos : Page
    {
        public CRUDProductos()
        {
            InitializeComponent();
        }

        #region REGRESAR
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Productos();
        }
        #endregion

        #region CRUD PRODUCTOS

        #region CREATE
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region DELETE
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region UPDATE
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #endregion

        #region SUBIR IMAGEN
        private void BtnCambiarImagen_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
