using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class CantCuentasResponse : ResponseHeader
    {
        protected DataTable Cuentas;
        public CantCuentasResponse(DataTable cuentas, int responseCode)
        {
            Cuentas = cuentas;
            ResponseCode = responseCode;
        }
        public CantCuentasResponse()
        {
            
        }
    }
}