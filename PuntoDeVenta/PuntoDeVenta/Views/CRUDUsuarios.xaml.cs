using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Lógica de interacción para CRUDUsuarios.xaml
    /// </summary>
    public partial class CRUDUsuarios : Page
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        private byte[] data;
        private bool imagenSubida = false;
        public int IdUsuario { get; set; }

        public CRUDUsuarios()
        {
            InitializeComponent();
            this.CargarCB();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Usuarios(); // cambiamos el contenido por una instancia de la vista Usuarios
        }

        void CargarCB()
        {
            try
            {
                this.conn.Open();
                string query = "SELECT NombrePrivilegio FROM Privilegios";
                SqlCommand cmd = new SqlCommand(query, this.conn);
                SqlDataReader readerSql = cmd.ExecuteReader();
                while (readerSql.Read())
                {
                    this.cbPrivilegio.Items.Add(readerSql["NombrePrivilegio"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible conectar con los datos");
            }
            finally
            {
                this.conn.Close();
            }

        }

        #region CRUD COMPLETO

        #region CREATE
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.tbNombre.Text == "" || this.tbApellido.Text == "" || this.tbDNI.Text == "" ||
                this.tbCUIT.Text == "" || this.tbCorreo.Text == "" || this.tbTelefono.Text == "" ||
                this.tbFecha.Text == "" || this.cbPrivilegio.Text == "" || this.tbUsuario.Text == "" || this.tbContrasenia.Text == "")
                {
                    MessageBox.Show("Los campos no pueden quedar vacíos");
                }
                else
                {
                    this.conn.Open();
                    string privilegioInput = this.cbPrivilegio.Text;
                    string queryPrivilegio = $"SELECT IdPrivilegio FROM Privilegios WHERE NombrePrivilegio='{privilegioInput}'";
                    SqlCommand cmd = new SqlCommand(queryPrivilegio, this.conn);
                    object valor = cmd.ExecuteScalar();
                    int privilegio = (int)valor;
                    string patron = "PuntoDeVenta";
                    if(this.imagenSubida == true)
                    {
                        string queryInsert = "INSERT INTO Usuarios (nombre, apellido, dni, cuit, fecha_nac, telefono, correo, privilegio, img, usuario, contrasenia) " +
                        "VALUES (@nombre, @apellido, @dni, @cuit, @fecha_nac, @telefono, @correo, @privilegio, @img, @usuario, " +
                        "(EncryptByPassPhrase('" + patron + "','" + this.tbContrasenia.Text + "')))";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, this.conn);
                        cmdInsert.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = this.tbNombre.Text;
                        cmdInsert.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = this.tbApellido.Text;
                        cmdInsert.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = int.Parse(this.tbDNI.Text);
                        cmdInsert.Parameters.Add("@cuit", System.Data.SqlDbType.Int).Value = int.Parse(this.tbCUIT.Text);
                        cmdInsert.Parameters.Add("@fecha_nac", System.Data.SqlDbType.Date).Value = this.tbFecha.Text;
                        cmdInsert.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = int.Parse(this.tbTelefono.Text);
                        cmdInsert.Parameters.Add("@correo", System.Data.SqlDbType.VarChar).Value = this.tbCorreo.Text;
                        cmdInsert.Parameters.Add("@privilegio", System.Data.SqlDbType.Int).Value = privilegio;
                        cmdInsert.Parameters.Add("@usuario", System.Data.SqlDbType.VarChar).Value = this.tbUsuario.Text;
                        cmdInsert.Parameters.AddWithValue("@img", System.Data.SqlDbType.VarBinary).Value = this.data;
                        cmdInsert.ExecuteNonQuery();
                        this.Content = new Usuarios();
                    }
                    else
                    {
                        MessageBox.Show("Debe agregar una foto de perfil para el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
        }
        #endregion

        #region READ
        public void Consultar()
        {
            try
            {
                this.conn.Open();
                string query = $"SELECT * FROM Usuarios " +
                    $"INNER JOIN Privilegios " +
                    $"ON Usuarios.Privilegio = Privilegios.IdPrivilegio " +
                    $"WHERE IdUsuario={this.IdUsuario}";
                SqlCommand cmd = new SqlCommand(query, this.conn);
                SqlDataReader readerSql = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                readerSql.Read();
                this.tbNombre.Text = readerSql["Nombre"].ToString();
                this.tbApellido.Text = readerSql["Apellido"].ToString();
                this.tbDNI.Text = readerSql["DNI"].ToString();
                this.tbCUIT.Text = readerSql["CUIT"].ToString();
                this.tbFecha.Text = readerSql["Fecha_nac"].ToString();
                this.tbTelefono.Text = readerSql["Telefono"].ToString();
                this.tbCorreo.Text = readerSql["Correo"].ToString();
                this.cbPrivilegio.SelectedItem = readerSql["NombrePrivilegio"];
                this.tbUsuario.Text = readerSql["usuario"].ToString();
                //this.tbContrasenia.Text = "Dato no disponible";
                readerSql.Close();

                // IMAGEN
                DataSet ds = new DataSet();
                string queryImg = $"SELECT img FROM Usuarios WHERE IdUsuario={this.IdUsuario}";
                SqlDataAdapter adapterSql = new SqlDataAdapter(queryImg, this.conn);
                adapterSql.Fill(ds);
                byte[] data = (byte[])ds.Tables[0].Rows[0][0];
                MemoryStream strm = new MemoryStream();
                strm.Write(data, 0, data.Length);
                strm.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                this.imagen.Source = bi;
                // IMAGEN
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
           

        }
        #endregion

        #region UPDATE
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.tbNombre.Text == "" || this.tbApellido.Text == "" || this.tbDNI.Text == "" ||
                    this.tbCUIT.Text == "" || this.tbCorreo.Text == "" || this.tbTelefono.Text == "" ||
                    this.tbFecha.Text == "" || this.cbPrivilegio.Text == "" || this.tbUsuario.Text == "")
                {
                    MessageBox.Show("Los campos no pueden quedar vacíos");
                }
                else
                {
                    this.conn.Open();
                    string privilegioInput = this.cbPrivilegio.Text;
                    string queryPrivilegio = $"SELECT IdPrivilegio FROM Privilegios WHERE NombrePrivilegio='{privilegioInput}'";
                    SqlCommand cmdPriv = new SqlCommand(queryPrivilegio, this.conn);
                    object valor = cmdPriv.ExecuteScalar();
                    int privilegio = (int)valor;
                    string contrasenia = this.tbContrasenia.Text;
                    string patron = "PuntoDeVenta";
                    string query = $"UPDATE Usuarios SET Nombre=@nombre, Apellido=@apellido, DNI=@dni, CUIT=@cuit, Fecha_nac=@fecha_nac, Telefono=@telefono, " +
                        $"Correo=@correo, Privilegio=@privilegio, Usuario=@usuario WHERE IdUsuario={this.IdUsuario}";
                    SqlCommand cmd = new SqlCommand(query, this.conn);
                    cmd.Parameters.AddWithValue("@nombre", System.Data.SqlDbType.VarChar).Value = this.tbNombre.Text;
                    cmd.Parameters.AddWithValue("@apellido", System.Data.SqlDbType.VarChar).Value = this.tbApellido.Text;
                    cmd.Parameters.AddWithValue("@dni", System.Data.SqlDbType.Int).Value = int.Parse(this.tbDNI.Text);
                    cmd.Parameters.AddWithValue("@cuit", System.Data.SqlDbType.Int).Value = int.Parse(this.tbCUIT.Text);
                    cmd.Parameters.AddWithValue("@fecha_nac", System.Data.SqlDbType.Date).Value = this.tbFecha.Text;
                    cmd.Parameters.AddWithValue("@telefono", System.Data.SqlDbType.Int).Value = int.Parse(this.tbTelefono.Text);
                    cmd.Parameters.AddWithValue("@correo", System.Data.SqlDbType.VarChar).Value = this.tbCorreo.Text;
                    cmd.Parameters.AddWithValue("@privilegio", System.Data.SqlDbType.Int).Value = privilegio;
                    cmd.Parameters.AddWithValue("@usuario", System.Data.SqlDbType.VarChar).Value = this.tbUsuario.Text;

                    if (this.imagenSubida == true)
                    {
                        string queryImg = $"UPDATE Usuarios SET img=@img WHERE IdUsuario={this.IdUsuario}";
                        SqlCommand imgCmd = new SqlCommand(queryImg, this.conn);
                        imgCmd.Parameters.AddWithValue("@img", SqlDbType.VarBinary).Value = this.data;
                        imgCmd.ExecuteNonQuery();
                    }
                    cmd.ExecuteNonQuery();

                    if(this.tbContrasenia.Text != "")
                    {
                        string queryPass = $"UPDATE Usuarios SET Contrasenia=(EncryptByPassPhrase('{patron}', '{contrasenia}')) " +
                            $"WHERE IdUsuario={this.IdUsuario}";
                        SqlCommand passCmd = new SqlCommand(queryPass, this.conn);
                        passCmd.ExecuteNonQuery();
                    }

                    this.Content = new Usuarios();
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
        }
        #endregion

        #region DELETE
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.conn.Open();
                string query = $"DELETE FROM Usuarios WHERE IdUsuario={this.IdUsuario}";
                SqlCommand cmd = new SqlCommand(query, this.conn);
                cmd.ExecuteNonQuery();
                this.Content = new Usuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
        }
        #endregion

        #endregion

        #region IMAGEN
        private void BtnCambiarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if (ofd.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    this.data = new byte[fs.Length];
                    fs.Read(this.data, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();

                    ImageSourceConverter imgs = new ImageSourceConverter();
                    this.imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                }
                this.imagenSubida = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion  
    }
}
