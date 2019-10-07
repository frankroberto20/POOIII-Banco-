using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServ
{
    public class RequestHeader
    {
        protected int CuentaOrigen;
        protected int Cedula;
        protected decimal Monto;
        protected DateTime dateTime;

        public RequestHeader()
        {

        }
    }
}
