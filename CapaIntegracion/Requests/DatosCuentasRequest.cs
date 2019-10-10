using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class DatosCuentaRequest
    {
        protected int NoCuenta;
        protected string Cedula;

        public DatosCuentaRequest(int noCuenta, string cedula)
        {
            this.NoCuenta = noCuenta;
            this.Cedula = cedula;
        }

        public DatosCuentaResponse DatosCuenta()
        {
            CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
            var datos = coreSoap.Movimiento_cuentas(NoCuenta.ToString(), Cedula);
            DatosCuentaResponse datosCuentaResponse = new DatosCuentaResponse(datos.Nombre_completo_solicitante, datos.Cedula, datos.Mensaje, datos.Monto, datos.DataTable);
            return datosCuentaResponse;
        }
    }
}