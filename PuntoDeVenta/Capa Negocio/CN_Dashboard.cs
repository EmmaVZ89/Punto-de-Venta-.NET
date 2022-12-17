using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Negocio
{
    public class CN_Dashboard
    {
        readonly CD_Dashboard objDash = new CD_Dashboard();

        public int CantidadVentas()
        {
            return this.objDash.CantidadVentas();
        }

        public decimal Articulos()
        {
            return this.objDash.Articulos();
        }

        public DataTable Grafico()
        {
            return this.objDash.Grafico();
        }
    }
}
