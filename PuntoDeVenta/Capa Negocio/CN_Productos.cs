using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Productos
    {
        readonly CD_Productos objProductos = new CD_Productos();

        // VISTA PRODUCTOS

        #region BUSCAR
        public DataTable BuscarProducto(string buscar)
        {
            return this.objProductos.Buscar(buscar);
        }
        #endregion

        // VISTA CRUD PRODUCTOS

        #region CRUD

        #region CONSULTAR
        public CE_Productos Consultar(int idArticulo)
        {
            return this.objProductos.Consultar(idArticulo);
        }
        #endregion

        #region INSERTAR
        public void Insertar(CE_Productos productos)
        {
            this.objProductos.CD_Insertar(productos);
        }
        #endregion

        #region ELIMINAR
        public void Eliminar(CE_Productos ce_productos)
        {
            this.objProductos.CD_Eliminar(ce_productos);
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void ActualizarDatos(CE_Productos productos)
        {
            this.objProductos.CD_Actualizar(productos);
        }
        #endregion

        #region ACTUALIZAR IMG
        public void ActualizarIMG(CE_Productos productos)
        {
            this.objProductos.CD_ActualizarIMG(productos);
        }
        #endregion

        #endregion
    }
}
