using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Productos
    {
        private int idArticulo;
        private string nombre;
        private int grupo;
        private string codigo;
        private decimal precio;
        private bool activo;
        private decimal cantidad;
        private string unidadMedida;
        private byte[] img;
        private string descripcion;

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Grupo { get => grupo; set => grupo = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public bool Activo { get => activo; set => activo = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
        public byte[] Img { get => img; set => img = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
