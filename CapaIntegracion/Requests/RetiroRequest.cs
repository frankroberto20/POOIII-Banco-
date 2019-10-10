using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CapaIntegracion
{
    public class RetiroRequest: RequestHeader
    {
        protected decimal Monto;
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        public RetiroRequest(int NoCuenta, string cedula, decimal monto)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
            Monto = monto;
        }

        public bool RealizarRetiroLocal()
        {
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();

            Logger.Info($"MINICORE: Solicitud retiro de {Monto} de cuenta {CuentaOrigen}");
            decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
            if (tblCuentas.GetTitular(CuentaOrigen) == Cedula)
            {
                if (balance >= Monto)
                {
                    //AGREGUE COLUMNA A MOVIMIENTOS 0(No se ha enviado a core), 1(si se envio)
                    tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Retiro", null, 0);
                    balance -= Monto;
                    tblCuentas.updateBalance(balance, DateTime.Now, CuentaOrigen);
                    
                    return true;
                }
                else
                    return false;
            }
            else
                return true;       
        }
        

        public RetiroResponse Retiro()
        {
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
            TblMovimientosTableAdapter tblMovimientos = new TblMovimientosTableAdapter();
            try
            {
                CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                var response = coreSoap.Retirar(Cedula, CuentaOrigen.ToString(), Monto);
                
                if (response.validar == 0)
                {
                    //ACTUALIZANDO MI BASE DE DATOS
                    tblMovimientos.Insert(CuentaOrigen, Monto, DateTime.Now, "Retiro", null, 1);
                    tblCuentas.updateBalance(tblCuentas.GetBalance(CuentaOrigen) - Monto, DateTime.Now, CuentaOrigen);
                    Logger.Info($"Retiro de {Monto} de la cuenta {CuentaOrigen} realizado ");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, 0, "Retiro Realizado");
                    return retiroResponse;
                }
                else
                {
                    Logger.Info($"Retiro FALLIDO de {Monto} de la cuenta {CuentaOrigen}. Razon: {response.Mensaje}");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, response.validar, response.Mensaje);
                    return retiroResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Info($"Core no disponible, utilizando base de datos local {e.Message}");
                bool x = RealizarRetiroLocal(); //depende del mensaje de error
                if (x)
                {
                    Logger.Info($"MINICORE: Retiro realizado de {Monto} de cuenta {CuentaOrigen}");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, 0, "Retiro Realizado");
                    return retiroResponse;
                }
                else
                {
                    Logger.Info($"MINICORE: Retiro FALLIDO de {Monto} de cuenta {CuentaOrigen}");
                    RetiroResponse retiroResponse = new RetiroResponse(DateTime.Now, 1, $"Retiro FALLIDO.");
                    return retiroResponse;
                }
            }
        }
    }
}