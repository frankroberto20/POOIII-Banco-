using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja
{
    public class Usuarios
    {
        private string apellido;
        private string nombre;
        private string sexo;
        private string edad;
        private string cedula;
        private string telefono;
        private string clave;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
    }
}
