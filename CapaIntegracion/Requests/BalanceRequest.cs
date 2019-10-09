using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;

namespace MainServ
{
    public class BalanceRequest : RequestHeader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BalanceRequest(int NoCuenta, int cedula)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
        }
        public BalanceRequest()
        {
            
        }


        public decimal BalanceLocal()
        {
            TblClientesTableAdapter tblClientes = new TblClientesTableAdapter(); //FALTA VALIDACION DE CEDULA
            TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();


            decimal balance = Convert.ToDecimal(tblCuentas.GetBalance(CuentaOrigen));

            return balance;
        }

        public BalanceResponse Balance()
        {

            try
            {
                decimal balance = 0; //webmethod
                //webmethod del core
                DateTime date = DateTime.Now;
                log.Info($"Chequeo de balance a cuenta {CuentaOrigen} a las {date}, realizado");
                BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 0, "Success", balance);
                return balanceResponse;
            }
            catch (WebException e)
            {
                TblCuentasTableAdapter tblCuentas = new TblCuentasTableAdapter();
                log.Info($"Core no disponible, utilizando base de datos local {e}");
                if (Cedula == Convert.ToInt32(tblCuentas.GetTitular(CuentaOrigen)))
                {
                    decimal balance = BalanceLocal(); //ConsultarBalance();
                    log.Info($"Chequeo de balance a cuenta {CuentaOrigen} realizado");
                    BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 0, "Success", balance); //ConsultarBalance();
                    return balanceResponse;
                }
                else
                {
                    log.Info($"Chequeo de balance a cuenta {CuentaOrigen} Fallido, cedula y cuenta no coinciden");
                    BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 1, "Cedula y Cuenta no coinciden", 0); //ConsultarBalance();
                    return balanceResponse;
                }
                
            }
        }
    }
}