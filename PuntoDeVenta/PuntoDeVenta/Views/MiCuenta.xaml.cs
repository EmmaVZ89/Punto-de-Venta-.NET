using Capa_Negocio;
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
using System.Windows.Shapes;

namespace PuntoDeVenta.Views
{
    public partial class MiCuenta : Window
    {
        public MiCuenta()
        {
            InitializeComponent();

            //string tema = Properties.Settings.Default.Tema;

            //this.fondo.Source = new BitmapImage(new Uri(@"/src/img/" + tema + ".png", UriKind.Relative));

            this.CargarDatos();
        }

        private void CargarDatos()
        {
            CN_Usuarios cn = new CN_Usuarios();
            var a = cn.Cargar(Properties.Settings.Default.IdUsuario);
            try
            {
                this.lblNombre.Text = $"Nombre: {a.Nombre}";
                this.lblApellido.Text = $"Apellido: {a.Apellido}";
                this.lblCorreo.Text = $"Correo: {a.Correo}";
                this.lblPrivilegio.Text = $"Privilegio: Nivel {a.Privilegio}";

                ImageSourceConverter imgs = new ImageSourceConverter();
                this.imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
