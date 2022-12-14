using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Usuarios
    {
        private readonly CD_Conexion conn = new CD_Conexion();
        private readonly CE_Usuarios capaEntidadUsuarios = new CE_Usuarios();

        // CRUD Usuarios

        #region INSERTAR
        public void CD_Insertar(CE_Usuarios usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_U_Insertar",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@DNI", usuario.Dni);
                cmd.Parameters.AddWithValue("@CUIT", usuario.Cuit);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.Add("@Fecha_Nac", SqlDbType.Date).Value = usuario.Fecha_Nac;
                cmd.Parameters.AddWithValue("@Privilegio", usuario.Privilegio);
                cmd.Parameters.AddWithValue("@Img", usuario.Img);
                cmd.Parameters.AddWithValue("@usuario", usuario.Usuario);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
                cmd.Parameters.AddWithValue("@patron", usuario.Patron);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region CONSULTAR
        public CE_Usuarios CD_Consultar(int IdUsuario)
        {
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_U_Consultar", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterSql.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            adapterSql.Fill(dataSet);
            DataTable dataTable;
            dataTable = dataSet.Tables[0];
            DataRow row = dataTable.Rows[0];
            this.capaEntidadUsuarios.Nombre = Convert.ToString(row[1]);
            this.capaEntidadUsuarios.Apellido = Convert.ToString(row[2]);
            this.capaEntidadUsuarios.Dni = Convert.ToInt32(row[3]);
            this.capaEntidadUsuarios.Cuit = Convert.ToInt32(row[4]);
            this.capaEntidadUsuarios.Correo = Convert.ToString(row[5]);
            this.capaEntidadUsuarios.Telefono = Convert.ToInt32(row[6]);
            this.capaEntidadUsuarios.Fecha_Nac = Convert.ToDateTime(row[7]);
            this.capaEntidadUsuarios.Privilegio = Convert.ToInt32(row[8]);
            this.capaEntidadUsuarios.Img = (byte[])row[9];
            this.capaEntidadUsuarios.Usuario = Convert.ToString(row[10]);

            return this.capaEntidadUsuarios;
        }
        #endregion

        #region ELIMINAR
        public void CD_Eliminar(CE_Usuarios usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_U_Eliminar",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void CD_ActualizarDatos(CE_Usuarios usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_U_ActualizarDatos",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@DNI", usuario.Dni);
                cmd.Parameters.AddWithValue("@CUIT", usuario.Cuit);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.Add("@Fecha_Nac", SqlDbType.Date).Value = usuario.Fecha_Nac;
                cmd.Parameters.AddWithValue("@Privilegio", usuario.Privilegio);
                cmd.Parameters.AddWithValue("@usuario", usuario.Usuario);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region ACTUALIZAR PASS
        public void CD_ActualizarPass(CE_Usuarios usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_U_ActualizarPass",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                cmd.Parameters.AddWithValue("@patron", usuario.Patron);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }

        #endregion

        #region ACTUALIZAR IMG
        public void CD_ActualizarIMG(CE_Usuarios usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_U_ActualizarIMG",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@img", usuario.Img);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion


        // VISTA DE USUARIOS

        #region CARGAR USUARIOS
        //public DataTable CargarUsuarios()
        //{
        //    DataTable dTable = new DataTable();

        //    try
        //    {
        //        SqlDataAdapter adapterSql = new SqlDataAdapter("SP_U_CargarUsuarios", this.conn.AbrirConexion());
        //        adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        DataSet dSet = new DataSet();
        //        dSet.Clear();
        //        adapterSql.Fill(dSet);
        //        dTable = dSet.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        this.conn.CerrarConexion();
        //    }
           
        //    return dTable;
        //}
        #endregion

        #region Buscar USUARIOS
        public DataTable Buscar(string buscar)
        {
            DataTable dTable = new DataTable();

            try
            {
                SqlDataAdapter adapterSql = new SqlDataAdapter("SP_U_Buscar", this.conn.AbrirConexion());
                adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapterSql.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = buscar;
                DataSet dSet = new DataSet();
                dSet.Clear();
                adapterSql.Fill(dSet);
                dTable = dSet.Tables[0];
            }
            finally
            {
                this.conn.CerrarConexion();
            }

            return dTable;
        }
        #endregion


        // LOGIN
        #region LOGIN
        public CE_Usuarios Login(string usuario, string contra)
        {
            string patron = "PuntoDeVenta";
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_U_Validar", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterSql.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
            adapterSql.SelectCommand.Parameters.Add("@Contra", SqlDbType.VarChar).Value = contra;
            adapterSql.SelectCommand.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
            DataSet dSet = new DataSet();
            dSet.Clear();
            adapterSql.Fill(dSet);
            DataTable dTable = dSet.Tables[0];
            if(dTable.Rows.Count > 0)
            {
                DataRow dRow = dTable.Rows[0];
                this.capaEntidadUsuarios.IdUsuario = Convert.ToInt32(dRow[0]);
                this.capaEntidadUsuarios.Privilegio = Convert.ToInt32(dRow[1]);
            }
            return this.capaEntidadUsuarios;
        }
        #endregion

    }
}
