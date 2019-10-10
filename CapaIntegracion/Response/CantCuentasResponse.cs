using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CapaIntegracion
{
    public class CantCuentasResponse : ResponseHeader
    {
        protected DataSet Cuentas;
        public CantCuentasResponse(DataSet cuentas)
        {
            Cuentas = cuentas;
        }
    }
}