using CapaIntegracion.IntegracionDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CapaIntegracion
{
    public class TransferenciaRequest : RequestHeader
    {
        protected string BancoDestino;
        protected int CuentaDestino;
        protected int CedulaDestino;
        protected decimal Monto;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

        public bool TransferenciaLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); 
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();

            log.Info($"MINICORE: Solicitud transferencia de {Monto} de cuenta {CuentaOrigen} a {CuentaDestino}");
            if (tblCuentas.GetTitular(CuentaOrigen) == Cedula && tblCuentas.GetTitular(CuentaDestino) == CedulaDestino)  
            {
                decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
                if (balance >= Monto)
                {
                    //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                    tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "transferencia", CuentaDestino, 0);
                    balance -= Monto;
                    tblCuentas.NuevoMovimiento(balance, DateTime.Now, CuentaOrigen);
                    decimal balanceDestino = Convert.ToDecimal(tblCuentas.GetBalance(CuentaDestino));
                    balanceDestino += Monto;
                    tblCuentas.NuevoMovimiento(balanceDestino, DateTime.Now, CuentaDestino);

                    return true;

                }
                else
                    return false;
            }
            else
                return false;


        }

        public TransferenciaResponse Transferencia()
        {
            if (BancoDestino.ToUpper() == "LOCAL")
            {
                try
                {
                    //webmethod del core
                    bool x = true; //webmethod
                    string message = "x"; //webmethod
                    if (x)
                    {
                        DateTime date = DateTime.Now;
                        log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, realizada");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 0, "Transferencia Realizada");
                        return transferenciaResponse;
                    }
                    else
                    {
                        DateTime date = DateTime.Now;
                        log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, no ha podido realizarse. Razon: {message}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 1, $"Transferencia no Realizada. Razon: {message}");
                        return transferenciaResponse;
                    }
                }
                catch (WebException e)
                {
                    log.Info($"Core no disponible, utilizando base de datos local {e}");
                    //NuevaTransferencia();
                    bool x = true; //depende del mensaje de error
                    string message = "x"; //depende del mensaje de error
                    if (x)
                    {
                        DateTime date = DateTime.Now;
                        log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, realizada");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 0, "Transferencia Realizada");
                        return transferenciaResponse;
                    }
                    else
                    {
                        DateTime date = DateTime.Now;
                        log.Info($"Transferencia de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino} a las {date}, no ha podido realizarse. Razon: {message}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(date, 1, $"Transferencia no Realizada. Razon: {message}");
                        return transferenciaResponse;
                    }
                }

            }
            else
            {
                TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 1, $"Transferencia no Realizada.");
                return transferenciaResponse;
            }
            


        }
    }
}