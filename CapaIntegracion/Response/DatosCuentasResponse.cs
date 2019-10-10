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
        protected DataSet DataSet;
        public DatosCuentaResponse(string nombre, string cedula, string mensaje, decimal monto, DataSet dataSet)
        {
            Nombre = nombre;
            Cedula = cedula;
            Mensaje = mensaje;
            Monto = monto;
            DataSet = dataSet;
        }
    }
}