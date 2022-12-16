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
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.tbUsuario.Focus();
        }

        private void Acceder(object sender, RoutedEventArgs e)
        {
            if(this.tbUsuario.Text != "" && this.tbContra.Text != "")
            {
                this.LoginUser(this.tbUsuario.Text, this.tbContra.Text);
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacios!");
            }
        }

        private void LoginUser(string usuario, string contra)
        {
            CN_Usuarios capaN = new CN_Usuarios();
            var a = capaN.Login(usuario, contra);

            if(a.IdUsuario > 0)
            {
                Properties.Settings.Default.IdUsuario = a.IdUsuario;
                Properties.Settings.Default.Privilegio = a.Privilegio;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña incorrectos!");
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
