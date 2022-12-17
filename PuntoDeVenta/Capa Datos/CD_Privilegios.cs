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
    public class CD_Privilegios
    {
        readonly CD_Conexion conn = new CD_Conexion();
        readonly CE_Privilegios cePrivilegios = new CE_Privilegios();

        #region IDPRIVILEGIO
        public int IdPrivilegio(string nombrePrivilegio)
        {
            //int idPrivilegio = 0;
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_P_IdPrivilegio",
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@NombrePrivilegio", nombrePrivilegio);
                object valor = cmd.ExecuteScalar();
                int idPrivilegio = (int)valor;
                return idPrivilegio;
            }
            finally
            {
                this.conn.CerrarConexion();
            }

            return 0;
        }
        #endregion

        #region NOMBREPRIVILEGIO
        public CE_Privilegios NombrePrivilegio(int idPrivilegio)
        {
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_P_NombrePrivilegio", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterSql.SelectCommand.Parameters.Add("@IdPrivilegio", SqlDbType.Int).Value = idPrivilegio;
            DataSet dSet = new DataSet();
            dSet.Clear();
            adapterSql.Fill(dSet);
            DataTable dTable;
            dTable = dSet.Tables[0];
            DataRow dRow = dTable.Rows[0];
            this.cePrivilegios.NombrePrivilegio = Convert.ToString(dRow[0]);

            return this.cePrivilegios;
        }
        #endregion

        #region LISTAR PRIVILEGIOS
        public List<string> ObtenerPrivilegios()
        {
            List<string> lista = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_P_CargarPrivilegio",
                    CommandType = CommandType.StoredProcedure,
                };
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(Convert.ToString(reader["NombrePrivilegio"]));
                }
            }
            finally
            {
                this.conn.CerrarConexion();
            }


            return lista;
        }
        #endregion

    }
}
