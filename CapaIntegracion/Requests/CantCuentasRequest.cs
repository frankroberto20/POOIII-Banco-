using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class CantCuentasRequest
    { 
        protected string Cedula;
        protected int ResponseCode;
        public CantCuentasResponse CantidadCuentas()
        {
            DataTable Cuentas = new DataTable();

            CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
            var Objeto = coreSoap.Mostrar_cuentas_del_cliente(Cedula); //webmethod(cedula);
            try
            {
                Cuentas = Objeto.DataTable;
                ResponseCode = 0;
            }
            catch (Exception e)
            {
                ResponseCode = 1;
            }
            CantCuentasResponse cantCuentasResponse = new CantCuentasResponse(Cuentas);
            return cantCuentasResponse;
        }
        public CantCuentasRequest(string cedula)
        {
            this.Cedula = cedula;
        }
    }
}