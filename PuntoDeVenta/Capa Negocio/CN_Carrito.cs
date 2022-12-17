using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Negocio
{
    public class CN_Carrito
    {
        private readonly CD_Carrito objCarrito = new CD_Carrito();

        #region BUSCAR
        public CE_Carrito Buscar(string buscar)
        {
            return this.objCarrito.Buscar(buscar);
        }
        #endregion

        #region AGREGAR
        public DataTable Agregar(string producto, decimal cantidad)
        {
            return this.objCarrito.Agregar(producto, cantidad);
        }
        #endregion

        #region VENTA
        public void Venta(string factura, decimal total, DateTime fecha, int idUsuario)
        {
            this.objCarrito.Venta(factura, total, fecha, idUsuario);
        }
        #endregion

        #region VENTA DETALLE
        public void Venta_Detalle(string codigo, decimal cantidad, string factura,  decimal totalArticulo)
        {
            this.objCarrito.Venta_Detalle(codigo, cantidad, factura,  totalArticulo);
        }
        #endregion
    }
}
