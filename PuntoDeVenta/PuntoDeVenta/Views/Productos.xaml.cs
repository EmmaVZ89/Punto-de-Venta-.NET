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
using Capa_Negocio;
using PuntoDeVenta.src.Boxes;

namespace PuntoDeVenta.Views
{
    public partial class Productos : UserControl
    {
        readonly CN_Productos obj_CN_Productos = new CN_Productos();
        Error error;

        #region INICIAL
        public Productos()
        {
            InitializeComponent();
            this.Buscar("");
        }
        #endregion

        #region BUSCADOR
        public void Buscar(string buscar)
        {
            try
            {
                this.GridDatos.ItemsSource = this.obj_CN_Productos.BuscarProducto(buscar).DefaultView;
            }
            catch (Exception ex)
            {
                this.error = new Error();
                this.error.lblError.Text = ex.Message;
                this.error.ShowDialog();
            }
        }

        private void Buscando(object sender, TextChangedEventArgs e)
        {
            this.Buscar(this.tbBuscar.Text);
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
            int id = (int)((Button)sender).CommandParameter;
            CRUDProductos ventana = new CRUDProductos();
            this.FrameProductos.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Consulta de Producto";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbCodigo.IsEnabled = false;
            ventana.tbCantidad.IsEnabled = false;
            ventana.tbActivo.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbGrupo.IsEnabled = false;
            ventana.tbUnidadMedida.IsEnabled = false;
            ventana.tbDescripcion.IsEnabled = false;
            ventana.BtnCambiarImagen.IsEnabled = false;
        }
        #endregion

        #region UPDATE
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDProductos ventana = new CRUDProductos();
            this.FrameProductos.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Modificar Producto";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbCodigo.IsEnabled = true;
            ventana.tbCantidad.IsEnabled = true;
            ventana.tbActivo.IsEnabled = true;
            ventana.tbPrecio.IsEnabled = true;
            ventana.cbGrupo.IsEnabled = true;
            ventana.tbUnidadMedida.IsEnabled = true;
            ventana.tbDescripcion.IsEnabled = true;
            ventana.BtnCambiarImagen.IsEnabled = true;
            ventana.BtnModificar.Visibility = Visibility.Visible;
        }
        #endregion

        #region DELETE
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDProductos ventana = new CRUDProductos();
            this.FrameProductos.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Eliminar Producto";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbCodigo.IsEnabled = false;
            ventana.tbCantidad.IsEnabled = false;
            ventana.tbActivo.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbGrupo.IsEnabled = false;
            ventana.tbUnidadMedida.IsEnabled = false;
            ventana.tbDescripcion.IsEnabled = false;
            ventana.BtnCambiarImagen.IsEnabled = false;
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }
        #endregion

        #endregion
    }
}
