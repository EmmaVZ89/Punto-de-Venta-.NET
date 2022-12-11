using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Usuarios
    {
        private int idUsuario;
        private string nombre;
        private string apellido;
        private int dni;
        private int cuit;
        private string correo;
        private int telefono;
        private DateTime fecha_Nac;
        private int privilegio;
        private byte[] img;
        private string usuario;
        private string contrasenia;
        private string patron;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Cuit { get => cuit; set => cuit = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_Nac { get => fecha_Nac; set => fecha_Nac = value; }
        public int Privilegio { get => privilegio; set => privilegio = value; }
        public byte[] Img { get => img; set => img = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Patron { get => patron; set => patron = value; }
    }
}
