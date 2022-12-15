using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Productos
    {
        CD_Conexion conn = new CD_Conexion();
        CE_Productos productos = new CE_Productos();

        // VISTAS PRODUCTOS

        #region BUSCAR
        public DataTable Buscar(string buscar)
        {
            DataTable dTable = new DataTable();
            try
            {
                SqlDataAdapter adapterSql = new SqlDataAdapter("SP_A_Buscar", this.conn.AbrirConexion());
                adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapterSql.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = buscar;
                DataSet dSet = new DataSet();
                dSet.Clear();
                adapterSql.Fill(dSet);
                dTable = dSet.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }

            return dTable;
        }
        #endregion

        // VISTA CRUD PRODUCTOS

        #region CRUD

        #region CONSULTAR
        public CE_Productos Consultar(int idProducto)
        {
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_A_Consultar", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterSql.SelectCommand.Parameters.Add("@IdArticulo", SqlDbType.Int).Value = idProducto;
            DataSet dSet = new DataSet();
            dSet.Clear();
            adapterSql.Fill(dSet);
            DataTable dTable;
            dTable = dSet.Tables[0];
            DataRow dRow = dTable.Rows[0];
            this.productos.Nombre = Convert.ToString(dRow[1]);
            this.productos.Grupo = Convert.ToInt32(dRow[2]);
            this.productos.Codigo = Convert.ToString(dRow[3]);
            this.productos.Precio = Convert.ToDouble(dRow[4]);
            this.productos.Activo = Convert.ToBoolean(dRow[5]);
            this.productos.Cantidad = Convert.ToDouble(dRow[6]);
            this.productos.UnidadMedida = Convert.ToString(dRow[7]);
            this.productos.Img = (byte[])dRow[8];
            this.productos.Descripcion = Convert.ToString(dRow[9]);

            return this.productos;
        }
        #endregion

        #region INSERTAR
        public void CD_Insertar(CE_Productos productos)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_A_Insertar",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@Grupo", productos.Grupo);
                cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
                cmd.Parameters.AddWithValue("@Precio", productos.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", productos.Cantidad);
                cmd.Parameters.AddWithValue("@Activo", productos.Activo);
                cmd.Parameters.AddWithValue("@UnidadMedida", productos.UnidadMedida);
                cmd.Parameters.AddWithValue("@Img", productos.Img);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region ELIMINAR
        public void CD_Eliminar(CE_Productos productos)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_A_Eliminar",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void CD_Actualizar(CE_Productos productos)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_A_Actualizar",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@Grupo", productos.Grupo);
                cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
                cmd.Parameters.AddWithValue("@Precio", productos.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", productos.Cantidad);
                cmd.Parameters.AddWithValue("@Activo", productos.Activo);
                cmd.Parameters.AddWithValue("@UnidadMedida", productos.UnidadMedida);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #region ACTUALIZAR IMG
        public void CD_ActualizarIMG(CE_Productos productos)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_A_ActualizarIMG",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdArticulo", productos.IdArticulo);
                cmd.Parameters.AddWithValue("@Img", productos.Img);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }
        }
        #endregion

        #endregion
    }
}
