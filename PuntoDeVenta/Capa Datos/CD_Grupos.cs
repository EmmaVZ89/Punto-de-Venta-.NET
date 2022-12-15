using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class CD_Grupos
    {
        CD_Conexion conn = new CD_Conexion();
        CE_Grupos cE_Grupos = new CE_Grupos();

        #region LISTAR GRUPOS
        public List<string> ListarGrupos()
        {
            List<string> retorno = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_G_CargarGrupos",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader dReader = cmd.ExecuteReader();
                while (dReader.Read())
                {
                    retorno.Add(Convert.ToString(dReader["Nombre"]));
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

            return retorno;
        }
        #endregion

        #region NOMBRE GRUPO
        public CE_Grupos Nombre(int idGrupo)
        {
            SqlDataAdapter adapterSql = new SqlDataAdapter("SP_G_NombreGrupo", this.conn.AbrirConexion());
            adapterSql.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapterSql.SelectCommand.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = idGrupo;
            DataSet dSet = new DataSet();
            dSet.Clear();
            adapterSql.Fill(dSet);
            DataTable dTable;
            dTable = dSet.Tables[0];
            DataRow dRow = dTable.Rows[0];
            this.cE_Grupos.Nombre = Convert.ToString(dRow[0]);

            return this.cE_Grupos;
        }
        #endregion

        #region IDGRUPO
        public int IdGrupo(string nombre)
        {
            int idGrupo = 0;

            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = this.conn.AbrirConexion(),
                    CommandText = "SP_G_IdGrupo",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                object valor = cmd.ExecuteScalar();
                idGrupo = (int)valor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.conn.CerrarConexion();
            }

            return idGrupo;
        }
        #endregion
    }
}
