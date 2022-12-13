using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Privilegios
    {
        CD_Privilegios CD_Privilegios = new CD_Privilegios();

        #region IDPRIVILEGIO
        public int IdPrivilegio(string nombrePrivilegio)
        {
            return this.CD_Privilegios.IdPrivilegio(nombrePrivilegio);
        }
        #endregion

        #region NOMBRE PRIVILEGIO
        public CE_Privilegios NombrePrivilegio(int idPrivilegio)
        {
            return this.CD_Privilegios.NombrePrivilegio(idPrivilegio);
        }
        #endregion

        #region LISTAR PRIVILEGIOS
        public List<string> ListarPrivilegios()
        {
            return this.CD_Privilegios.ObtenerPrivilegios();
        }
        #endregion
    }
}
