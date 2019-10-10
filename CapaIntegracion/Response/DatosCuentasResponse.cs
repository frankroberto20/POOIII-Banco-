using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class DatosCuentaResponse : ResponseHeader
    {
        protected string Nombre;
        protected string Cedula;
        protected string Mensaje;
        protected decimal Monto;
        protected DataTable DataTable;
        public DatosCuentaResponse(string nombre, string cedula, string mensaje, decimal monto, DataTable dataTable)
        {
            Nombre = nombre;
            Cedula = cedula;
            Mensaje = mensaje;
            Monto = monto;
            DataTable = dataTable;
        }
        public DatosCuentaResponse()
        {
            
        }
    }
}