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
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        public DepositoRequest(int NoCuenta, int cedula, decimal monto)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
            Monto = monto;
        }

        public bool DepositoLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); //No USA VALIDACION DE CEDULA
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();


            Logger.Info($"MINICORE: Solicitud retiro de {Monto} de cuenta {CuentaOrigen}");

            if (tblCuentas.exists(CuentaOrigen) == 1)
            {
                decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
                //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Retiro", null, 0);
                balance += Monto;
                tblCuentas.NuevoMovimiento(balance, DateTime.Now, CuentaOrigen);
                return true;
            }
            else
                return false;
        }


        public DepositoResponse Deposito()
        {
            try
            {
                //TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
                //tblCuentas.Insert(2, "Ahorro", 402, 0, DateTime.Now, DateTime.Now);
                CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                var response = coreSoap.Depositar("Cesar",Cedula.ToString(),CuentaOrigen.ToString(), Monto.ToString());
                Logger.Info($"Deposito de {Monto} a la cuenta {CuentaOrigen} realizado");
                DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 0, "Deposito Realizado");
                return depositoResponse;
            }
            catch (WebException e)
            {
                Logger.Info($"Core no disponible, utilizando base de datos local {e}");
                bool x = DepositoLocal(); //depende del mensaje de error
                if (x)
                {
                    Logger.Info($"MINICORE: Deposito realizado de {Monto} de cuenta {CuentaOrigen}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 0, "Retiro Realizado");
                    return depositoResponse;
                }
                else
                {
                    Logger.Info($"MINI: Deposito FALLIDO de {Monto} de cuenta {CuentaOrigen}");
                    DepositoResponse depositoResponse = new DepositoResponse(DateTime.Now, 1, $"Retiro FALLIDO"); 
                    return depositoResponse;
                }
            }
        }
    }
}