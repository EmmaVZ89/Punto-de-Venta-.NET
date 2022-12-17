using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Dashboard
    {
        CD_Conexion conn = new CD_Conexion();

        #region CANTIDAD VENTAS
        public int CantidadVentas()
        {
            int total;
            SqlCommand adapterSql = new SqlCommand("SP_D_CantidadVentas", this.conn.AbrirConexion());
            adapterSql.CommandType = System.Data.CommandType.StoredProcedure;
            total = (int)adapterSql.ExecuteScalar();
            this.conn.CerrarConexion();

            return total;
        }
        #endregion

        #region ARTICULOS DISPONIBLES
        public decimal Articulos()
        {
            SqlCommand adapterSql = new SqlCommand("SP_D_Articulos", this.conn.AbrirConexion());
            adapterSql.CommandType = CommandType.StoredProcedure;
            SqlDataReader dReader = adapterSql.ExecuteReader();
            decimal total;
            dReader.Read();
            total = (decimal)dReader[0];
            dReader.Close();
            this.conn.CerrarConexion();

            return total;
        }
        #endregion

        #region GRAFICO
        public DataTable Grafico()
        {
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_D_Grafico", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dSet = new DataSet();
            dSet.Clear();
            adapterSql.Fill(dSet);
            DataTable dTable;
            dTable = dSet.Tables[0];
            this.conn.CerrarConexion();

            return dTable;
        }
        #endregion
    }
}
