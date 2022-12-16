using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();

        // CRUD USUARIOS

        #region CONSULTAR
        public CE_Usuarios Consultar(int IdUsuario)
        {
            return objDatos.CD_Consultar(IdUsuario);
        }
        #endregion

        #region INSERTAR
        public void Insertar(CE_Usuarios usuario)
        {
            this.objDatos.CD_Insertar(usuario);
        }
        #endregion

        #region ELIMINAR
        public void Eliminar(CE_Usuarios usuario)
        {
            this.objDatos.CD_Eliminar(usuario);
        }
        #endregion

        #region ACTUALIZAR DATOS
        public void ActualizarDatos(CE_Usuarios usuario)
        {
            this.objDatos.CD_ActualizarDatos(usuario);
        }
        #endregion

        #region ACTUALIZAR PASS
        public void ActualizarPass(CE_Usuarios usuario)
        {
            this.objDatos.CD_ActualizarPass(usuario);
        }
        #endregion

        #region ACTUALIZAR IMÁGEN
        public void ActualizarIMG(CE_Usuarios usuario)
        {
            this.objDatos.CD_ActualizarIMG(usuario);
        }
        #endregion

        // VISTA USUARIOS

        //#region CARGAR USUARIOS
        //public DataTable CargarUsuarios()
        //{
        //    return this.objDatos.CargarUsuarios();
        //}
        //#endregion

        #region BUSCAR USUARIOS
        public DataTable Buscar(string buscar)
        {
            return this.objDatos.Buscar(buscar);
        }
        #endregion


        // LOGIN

        #region LOGIN
        public CE_Usuarios Login(string usuario, string contra)
        {
            return this.objDatos.Login(usuario, contra);
        }
        #endregion

    }
}
