using Capa_Negocio;
using PuntoDeVenta.src.Boxes;
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
    public partial class Login : Window
    {
        Error error;

        public Login()
        {
            InitializeComponent();
            this.tbUsuario.Focus();
        }

        private void Acceder(object sender, RoutedEventArgs e)
        {
            if(this.tbUsuario.Text != "" && this.tbContra.Text != "")
            {
                try
                {
                    this.LoginUser(this.tbUsuario.Text, this.tbContra.Text);
                }
                catch (Exception ex)
                {
                    this.error = new Error();
                    this.error.lblError.Text = ex.Message;
                    this.error.ShowDialog();
                }
            }
            else
            {
                this.error = new Error();
                this.error.lblError.Text = "Los campos no pueden quedar vacios";
                this.error.ShowDialog();
                //MessageBox.Show("Los campos no pueden quedar vacios!");
            }
        }

        private void LoginUser(string usuario, string contra)
        {
            try
            {
                CN_Usuarios capaN = new CN_Usuarios();
                var a = capaN.Login(usuario, contra);

                if (a.IdUsuario > 0)
                {
                    Properties.Settings.Default.IdUsuario = a.IdUsuario;
                    Properties.Settings.Default.Privilegio = a.Privilegio;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    this.error = new Error();
                    this.error.lblError.Text = "Usuario y/o Contraseña incorrectos!";
                    this.error.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.error = new Error();
                this.error.lblError.Text = ex.Message;
                this.error.ShowDialog();
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
