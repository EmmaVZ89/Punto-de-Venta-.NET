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
using Capa_Entidad;
using Microsoft.Win32;
using System.IO;

namespace PuntoDeVenta.Views
{
    public partial class CRUDProductos : Page
    {
        public int IdProducto;
        public string Patron = "PuntoDeVenta";
        private byte[] data;
        private bool imagenSubida = false;
        CN_Grupos objeto_CN_Grupos = new CN_Grupos();
        CN_Productos objeto_CN_Productos = new CN_Productos();
        CE_Productos objeto_CE_Productos = new CE_Productos();


        #region INICIAL
        public CRUDProductos()
        {
            InitializeComponent();
            this.Cargar();
        }
        #endregion

        #region REGRESAR
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Productos();
        }
        #endregion

        #region LLENAR GRUPOS
        private void Cargar()
        {
            List<string> grupos = this.objeto_CN_Grupos.ListarGrupos();
            for(int i = 0; i < grupos.Count; i++)
            {
                this.cbGrupo.Items.Add(grupos[i]);
            }
        }
        #endregion

        #region VALIDAR CAMPOS
        public bool ValidarCampos()
        {
            if(this.tbNombre.Text == "" || this.tbCodigo.Text == "" || this.cbGrupo.Text == "" || this.tbPrecio.Text == "" ||
               this.tbCantidad.Text == "" || this.tbUnidadMedida.Text == "" || this.tbDescripcion.Text == "")
            {
                return false;
            }
            return true;
        }
        #endregion

        #region CRUD PRODUCTOS

        #region CREATE
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            if(this.ValidarCampos() == true)
            {
                int idGrupo = this.objeto_CN_Grupos.IdGrupo(this.cbGrupo.Text);

                this.objeto_CE_Productos.Nombre = this.tbNombre.Text;
                this.objeto_CE_Productos.Codigo = this.tbCodigo.Text;
                this.objeto_CE_Productos.Precio = Decimal.Parse(this.tbPrecio.Text);
                this.objeto_CE_Productos.Cantidad = Decimal.Parse(this.tbCantidad.Text);
                this.objeto_CE_Productos.Activo = (bool)this.tbActivo.IsChecked;
                this.objeto_CE_Productos.UnidadMedida = this.tbUnidadMedida.Text;
                this.objeto_CE_Productos.Img = this.data;
                this.objeto_CE_Productos.Descripcion = this.tbDescripcion.Text;
                this.objeto_CE_Productos.Grupo = idGrupo;

                this.objeto_CN_Productos.Insertar(this.objeto_CE_Productos);

                this.Content = new Productos();
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacíos!");
            }
        }
        #endregion

        #region READ
        public void Consultar()
        {
            var cnProd = this.objeto_CN_Productos.Consultar(this.IdProducto);
            this.tbNombre.Text = cnProd.Nombre.ToString();
            this.tbCodigo.Text = cnProd.Codigo.ToString();
            this.tbPrecio.Text = cnProd.Precio.ToString();
            this.tbActivo.IsChecked = cnProd.Activo;
            this.tbCantidad.Text = cnProd.Cantidad.ToString();
            this.tbUnidadMedida.Text = cnProd.UnidadMedida.ToString();
            ImageSourceConverter imgs = new ImageSourceConverter();
            this.imagen.Source = (ImageSource)imgs.ConvertFrom(cnProd.Img);
            this.tbDescripcion.Text = cnProd.Descripcion.ToString();

            var cnGro = this.objeto_CN_Grupos.Nombre(cnProd.Grupo);

            this.cbGrupo.Text = cnGro.Nombre;
        }
        #endregion

        #region DELETE
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.objeto_CE_Productos.IdArticulo = this.IdProducto;
            this.objeto_CN_Productos.Eliminar(this.objeto_CE_Productos);
            this.Content = new Productos();
        }
        #endregion

        #region UPDATE
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidarCampos() == true)
            {
                int idGrupo = this.objeto_CN_Grupos.IdGrupo(this.cbGrupo.Text);

                this.objeto_CE_Productos.IdArticulo = this.IdProducto;
                this.objeto_CE_Productos.Nombre = this.tbNombre.Text;
                this.objeto_CE_Productos.Codigo = this.tbCodigo.Text;
                this.objeto_CE_Productos.Precio = Decimal.Parse(this.tbPrecio.Text);
                this.objeto_CE_Productos.Cantidad = Decimal.Parse(this.tbCantidad.Text);
                this.objeto_CE_Productos.Activo = (bool)this.tbActivo.IsChecked;
                this.objeto_CE_Productos.UnidadMedida = this.tbUnidadMedida.Text;
                this.objeto_CE_Productos.Descripcion = this.tbDescripcion.Text;
                this.objeto_CE_Productos.Grupo = idGrupo;

                this.objeto_CN_Productos.ActualizarDatos(this.objeto_CE_Productos);

                this.Content = new Productos();
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacíos!");
            }

            if(this.imagenSubida == true)
            {
                this.objeto_CE_Productos.IdArticulo = this.IdProducto;
                this.objeto_CE_Productos.Img = this.data;

                this.objeto_CN_Productos.ActualizarIMG(this.objeto_CE_Productos);
                this.Content = new Productos();
            }
        }
        #endregion

        #endregion

        #region SUBIR IMAGEN
        private void BtnCambiarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if(openFD.ShowDialog() == true)
            {
                FileStream fStream = new FileStream(openFD.FileName, FileMode.Open, FileAccess.Read);
                this.data = new byte[fStream.Length];
                fStream.Read(this.data, 0, Convert.ToInt32(fStream.Length));
                fStream.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                this.imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(openFD.FileName.ToString()));
            }
            this.imagenSubida = true;
        }
        #endregion
    }
}
