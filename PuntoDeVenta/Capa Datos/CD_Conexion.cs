using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        private string connectionString;
        private readonly SqlConnection conn;

        public CD_Conexion()
        {
            this.connectionString = "Data Source=DESKTOP-ERJMT07; initial catalog=PuntoDeVenta; integrated security=true;";
            this.conn = new SqlConnection(this.connectionString);
        }

        public SqlConnection AbrirConexion()
        {
            if(this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }
            return this.conn;
        }

        public SqlConnection CerrarConexion()
        {
            if(this.conn.State == ConnectionState.Open)
            {
                this.conn.Close();
            }
            return this.conn;
        }




    }
}
