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
            finally
            {
                this.conn.CerrarConexion();
            }

            return dTable;
        }
        #endregion

        #region VENTA
        public void Venta(string factura, decimal total, DateTime fecha, int idUsuario)
        {
            SqlCommand cmd = new SqlCommand("SP_C_Venta", this.conn.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No_Factura", SqlDbType.VarChar).Value = factura;
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            this.conn.CerrarConexion();
        }
        #endregion

        #region VENTA DETALLE
        public void Venta_Detalle(string codigo, decimal cantidad, string factura, decimal totalArticulo)
        {
            SqlCommand cmd = new SqlCommand("SP_C_Venta_Detalle", this.conn.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = codigo;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = cantidad;
            cmd.Parameters.Add("@No_Factura", SqlDbType.VarChar).Value = factura;
            cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = totalArticulo;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            this.conn.CerrarConexion();
        }
        #endregion

    }
}
