using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CapaIntegracion
{
    public class TransferenciaRequest : RequestHeader
    {
        public string BancoDestino;
        public int CuentaDestino;
        public string CedulaDestino;
        public decimal Monto;

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        public TransferenciaRequest(int cuentaOrigen, string cedula, decimal monto, string bancoDestino, int cuentaDestino, string cedulaDestino)
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
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();
            Logger.Info($"MINICORE: Solicitud transferencia de {Monto} de cuenta {CuentaOrigen} a {CuentaDestino}");
            if (Convert.ToBoolean(tblCuentas.exists(CuentaOrigen)) && Convert.ToBoolean(tblCuentas.exists(CuentaDestino)) && tblCuentas.GetTitular(CuentaOrigen) == Cedula && tblCuentas.GetTitular(CuentaDestino) == CedulaDestino)  
            {
                decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
                if (balance >= Monto)
                {
                    //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                    tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "transferencia", CuentaDestino, 0);
                    balance -= Monto;
                    tblCuentas.updateBalance(balance, DateTime.Now, CuentaOrigen);
                    
                    decimal balanceDestino = Convert.ToDecimal(tblCuentas.GetBalance(CuentaDestino));
                    balanceDestino += Monto;
                    tblCuentas.updateBalance(balanceDestino, DateTime.Now, CuentaDestino);

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
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();
            if (BancoDestino.ToUpper() == "LOCAL")
            {
                try
                {
                    CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                    var response = coreSoap.Retirar(Cedula, CuentaOrigen.ToString(), Monto); //RETIRO
                    

                    if (response.validar == 0)
                    {
                        tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "retiro", CuentaDestino, 1);
                        tblCuentas.updateBalance(tblCuentas.GetBalance(CuentaOrigen) - Monto, DateTime.Now, CuentaOrigen); //actualizando mi base de datos local

                        coreSoap.Depositar(CedulaDestino, CuentaDestino.ToString(), Monto); //DEPOSITO

                        tblMovimientos.Insert(CuentaDestino, Monto, DateTime.Now, "deposito", CuentaOrigen, 1);
                        tblCuentas.updateBalance(tblCuentas.GetBalance(CuentaDestino) + Monto, DateTime.Now, CuentaDestino); //actualizando mi base de datos local

                        Logger.Info($"Transferencia realizada de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 0, "Transferencia Realizada");
                        return transferenciaResponse;
                    }
                    else
                    {
                        Logger.Fatal($"Transferencia FALLIDA de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 1, $"Transferencia FALLIDA");
                        return transferenciaResponse;
                    }
                }
                catch (Exception e)
                {
                    Logger.Info($"Core no disponible, utilizando base de datos local {e}");
                    bool x = TransferenciaLocal(); //depende del mensaje de error
                    if (x)
                    {
                        Logger.Info($"Transferencia realizada de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 0, "Transferencia Realizada");
                        return transferenciaResponse;
                    }
                    else
                    {
                        Logger.Fatal($"Transferencia FALLIDA de {Monto} de la cuenta {CuentaOrigen} a {CuentaDestino}");
                        TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 1, $"Transferencia FALLIDA");
                        return transferenciaResponse;
                    }
                }

            }
            else
            {
                //METODOS INTERBANCARIOS
                TransferenciaResponse transferenciaResponse = new TransferenciaResponse(DateTime.Now, 2, $"Transferencia no Realizada.");
                return transferenciaResponse;
            }
            


        }
    }
}