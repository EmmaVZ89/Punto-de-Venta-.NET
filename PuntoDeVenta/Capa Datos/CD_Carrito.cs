using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Carrito
    {
        CD_Conexion conn = new CD_Conexion();
        CE_Carrito carrito = new CE_Carrito();

        #region BUSCAR
        public CE_Carrito Buscar(string buscar)
        {
            try
            {
                SqlDataAdapter adapterSql = new SqlDataAdapter("SP_C_Buscar", this.conn.AbrirConexion());
                adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapterSql.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = buscar;
                DataSet dSet = new DataSet();
                dSet.Clear();
                adapterSql.Fill(dSet);
                DataTable dTable = dSet.Tables[0];
                if (dTable.Rows.Count > 0)
                {
                    DataRow dRow = dTable.Rows[0];
                    this.carrito.Nombre = Convert.ToString(dRow[1]);
                    this.carrito.Precio = Convert.ToDecimal(dRow[4]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }

            return this.carrito;
        }
        #endregion

        #region AGREGAR
        public DataTable Agregar(string producto, decimal cantidad)
        {
            DataTable dTable = new DataTable();

            try
            {
                SqlDataAdapter adapterSql = new SqlDataAdapter("SP_C_Buscar", this.conn.AbrirConexion());
                adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapterSql.SelectCommand.Parameters.Add("@buscar", SqlDbType.VarChar).Value = producto;
                DataSet dSet = new DataSet();
                dSet.Clear();
                adapterSql.Fill(dSet);
                dTable = dSet.Tables[0];

                var precio = dTable.Rows[0][4];
                decimal cant = cantidad;
                decimal prodTotal = cant * (decimal)precio;

                dTable.Columns.Add("ProductoTotal", typeof(decimal));

                foreach (DataRow row in dTable.Rows)
                {
                    row["Cantidad"] = cantidad;
                    row["ProductoTotal"] = prodTotal;
                }
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
    }
}
