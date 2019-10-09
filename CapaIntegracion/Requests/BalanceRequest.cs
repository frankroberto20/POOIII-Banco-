using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;

namespace CapaIntegracion
{
    public class BalanceRequest : RequestHeader
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        public BalanceRequest(int NoCuenta, int cedula)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
        }

        public decimal BalanceLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); 
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();

                    decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));
                    return balance;
        }

        public BalanceResponse Balance()
        {

            try
            {
                decimal balance = 0;
                CoreServices.WebServicesCoreSoapClient coreSoap = new CoreServices.WebServicesCoreSoapClient();
                var response = coreSoap.Consulta_de_balance(Cedula.ToString(), CuentaOrigen.ToString());
                Logger.Info($"Chequeo de balance a cuenta {CuentaOrigen} realizado");
                BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 0, "Success", balance);
                return balanceResponse;
            }
            catch (WebException e)
            {
                TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
                Logger.Info($"Core no disponible, utilizando base de datos local {e}");
                if (Cedula == Convert.ToInt32(tblCuentas.GetTitular(CuentaOrigen)) && Convert.ToBoolean(tblCuentas.exists(CuentaOrigen)))
                {
                    decimal balance = BalanceLocal(); //ConsultarBalance();
                    Logger.Info($"MINICORE: Chequeo de balance a cuenta {CuentaOrigen} realizado");
                    BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 0, "Success", balance); //ConsultarBalance();
                    return balanceResponse;
                }
                else
                {
                    Logger.Info($"MINICORE: Chequeo de balance a cuenta {CuentaOrigen} Fallido, cedula y cuenta no coinciden");
                    BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 1, "Cedula y Cuenta no coinciden", 0); //ConsultarBalance();
                    return balanceResponse;
                }
                
            }
        }
    }
}