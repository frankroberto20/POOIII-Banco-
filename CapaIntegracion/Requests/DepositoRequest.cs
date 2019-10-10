using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CapaIntegracion
{
    public class DepositoRequest : RequestHeader
    {

        protected decimal Monto;
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        public DepositoRequest(int NoCuenta, string cedula, decimal monto)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
            Monto = monto;
        }

        public bool DepositoLocal()
        {
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();

            Logger.Info($"MINICORE: Solicitud deposito de {Monto} de cuenta {CuentaOrigen}");

            if (Convert.ToBoolean(tblCuentas.exists(CuentaOrigen)))
            {
                decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
                //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Deposito", null, 0);
                balance += Monto;
                tblCuentas.updateBalance(balance, DateTime.Now, CuentaOrigen);
                return true;
            }
            else
                return false;
        }

        public DepositoResponse Deposito()
        {
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();
            try
            {
                CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                var response = coreSoap.Depositar(Cedula, CuentaOrigen.ToString(), Monto);
                //VALIDAR ES DONDE ESTA 0 SI PASO, OTRO NUMERO SI NO
                if (response.validar == 0)
                {
                    //ACTUALIZANDO MI BASE DE DATOS
                    tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Deposito", null, 1);
                    tblCuentas.updateBalance(tblCuentas.GetBalance(CuentaOrigen) + Monto, DateTime.Now, CuentaOrigen);
                    Logger.Info($"Deposito de {Monto} a la cuenta {CuentaOrigen} realizado");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, response.validar, response.Mensaje);
                    return depositoResponse;
                }
                else
                {
                    Logger.Fatal($"Deposito FALLIDO de {Monto} a la cuenta {CuentaOrigen}, {response.Mensaje}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, response.validar, response.Mensaje);
                    return depositoResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Info($"Core no disponible, utilizando base de datos local {e.Message}");
                bool x = DepositoLocal(); //depende del mensaje de error
                if (x)
                {
                    Logger.Info($"MINICORE: Deposito realizado de {Monto} de cuenta {CuentaOrigen}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 0, "Retiro Realizado");
                    return depositoResponse;
                }
                else
                {
                    Logger.Fatal($"MINI: Deposito FALLIDO de {Monto} de cuenta {CuentaOrigen}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 1, $"Retiro FALLIDO"); 
                    return depositoResponse;
                }
            }
        }
    }
}