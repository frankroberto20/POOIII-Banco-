using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainServ
{
    public class TransferenciaRequest: RequestHeader
    {
        private string BancoDestino;
        private int CuentaDestino;
        private int CedulaDestino;
        public TransferenciaRequest(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            CuentaOrigen = cuentaOrigen;
            Cedula = cedula;
            Monto = monto;
            dateTime = DateTime.Now;

            BancoDestino = bancoDestino;
            CuentaDestino = cuentaDestino;
            CedulaDestino = cedulaDestino;
            
        }
        public TransferenciaResponse Transferencia()
        {
            TransferenciaResponse transferenciaResponse = new TransferenciaResponse();
            return transferenciaResponse;
        }


    }
}