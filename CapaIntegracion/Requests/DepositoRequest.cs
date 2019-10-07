using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class DepositoRequest : RequestHeader
    {
        private decimal Monto;

        public DepositoResponse Deposito()
        {
            DepositoResponse depositoResponse = new DepositoResponse();
            return depositoResponse;
        }
    }
}