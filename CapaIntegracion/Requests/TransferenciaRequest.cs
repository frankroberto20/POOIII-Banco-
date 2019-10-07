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
        private decimal Monto;

        public TransferenciaRequest(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            CuentaOrigen = cuentaOrigen;
            Cedula = cedula;
            Monto = monto;
            BancoDestino = bancoDestino;
            CuentaDestino = cuentaDestino;
            CedulaDestino = cedulaDestino;
            dateTime = DateTime.Now;


        }
        public TransferenciaResponse Transferencia(DateTime date, int responseCode, string responseMessage)
        {
            TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, responseCode, responseMessage);
            return transferenciaResponse;
        }


    }
}