using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Usuarios : UserControl
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        Error error;
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);

        #region INICIAL
        public Usuarios()
        {
            InitializeComponent();
            //this.CargarDatos();
            this.Buscar("");
        }
        #endregion

        //#region CARGAR USUARIOS
        //public void CargarDatos()
        //{
        //    this.GridDatos.ItemsSource = this.objeto_CN_Usuarios.CargarUsuarios().DefaultView;
        //    //try
        //    //{
        //    //    this.conn.Open();
        //    //    string query = "SELECT IdUsuario, Nombre, Apellido, Telefono, Correo, NombrePrivilegio FROM Usuarios " +
        //    //        "INNER JOIN Privilegios " +
        //    //        "ON Usuarios.Privilegio=Privilegios.IdPrivilegio " +
        //    //        "ORDER BY IdUsuario ASC";
        //    //    SqlCommand cmd = new SqlCommand(query, this.conn);
        //    //    SqlDataAdapter adapterSql = new SqlDataAdapter(cmd);
        //    //    DataTable dt = new DataTable();
        //    //    adapterSql.Fill(dt);
        //    //    this.GridDatos.ItemsSource = dt.DefaultView;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("No fue posible conectarse con los datos");
        //    //}
        //    //finally
        //    //{
        //    //    this.conn.Close();
        //    //}
        //}
        //#endregion

        #region AGREGAR
        private void BtnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            CRUDUsuarios ventana = new CRUDUsuarios();
            // Anteriormente cree el FrameUsuarios que ocupa toda la vista de la Vista Usuario
            this.FrameUsuarios.Content = ventana; // aca hago que el contenido del FrameUsuario sea la ventana CRUDUsuarios
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region CONSULTAR
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            this.FrameUsuarios.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Consulta de Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbDNI.IsEnabled = false;
            ventana.tbCUIT.IsEnabled = false;
            ventana.tbFecha.IsEnabled = false;
            ventana.tbTelefono.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.cbPrivilegio.IsEnabled = false;
            ventana.tbUsuario.IsEnabled = false;
            ventana.tbContrasenia.IsEnabled = false;
            ventana.BtnCambiarImagen.IsEnabled = false;
        }
        #endregion

        #region ACTUALIZAR
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            this.FrameUsuarios.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Modificar Usuario";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbApellido.IsEnabled = true;
            ventana.tbDNI.IsEnabled = true;
            ventana.tbCUIT.IsEnabled = true;
            ventana.tbFecha.IsEnabled = true;
            ventana.tbTelefono.IsEnabled = true;
            ventana.tbCorreo.IsEnabled = true;
            ventana.cbPrivilegio.IsEnabled = true;
            ventana.tbUsuario.IsEnabled = true;
            ventana.tbContrasenia.IsEnabled = true;
            ventana.BtnCambiarImagen.IsEnabled = true;
            ventana.BtnModificar.Visibility = Visibility.Visible;
        }
        #endregion

        #region ELIMINAR
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            this.FrameUsuarios.Content = ventana;
            this.Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Eliminar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbDNI.IsEnabled = false;
            ventana.tbCUIT.IsEnabled = false;
            ventana.tbFecha.IsEnabled = false;
            ventana.tbTelefono.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.cbPrivilegio.IsEnabled = false;
            ventana.tbUsuario.IsEnabled = false;
            ventana.tbContrasenia.IsEnabled = false;
            ventana.BtnCambiarImagen.IsEnabled = false;
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }
        #endregion

        #region BUSCADOR USUARIOS
        private void Buscar(string buscar)
        {
            try
            {
                this.GridDatos.ItemsSource = this.objeto_CN_Usuarios.Buscar(buscar).DefaultView;
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
    }
}
