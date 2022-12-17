using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Carrito
    {
        private string codigo;
        private string nombre;
        private decimal cantidad;
        private decimal precio;
        private decimal total;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
