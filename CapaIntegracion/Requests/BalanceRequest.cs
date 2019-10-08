using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CapaIntegracion.IntegracionDSTableAdapters;
using log4net;

namespace MainServ
{
    
    /*
    public decimal ConsultarBalance()
    {
        log.Info($"Solicitud de Consulta de balance de cuenta {idCuentaSolicitante}");
        BalanceResponse balanceResponse = new BalanceResponse();
        BankData bankData = new BankData();
        tblResponses tblResponses = new tblResponses();
        tblResponses.Request = "Solicitud de consulta de balance";
        tblResponses.Fecha = DateTime.Now;
        try
        {
            var balance = bancoEntities.BuscarBalance(idCuentaSolicitante);
            double n = 0;
            foreach (var row in balance)
            {
                n = double.Parse(row.ToString());
            }
            ResponseConsultaBalance = new ResponseConsultaBalance($"Balance actual: RD {n}");
            Console.WriteLine(ResponseConsultaBalance.Mensaje);

            tblResponses.Resultado = "Satisfactorio";
        }
        catch (Exception e)
        {
            ResponseConsultaBalance = new ResponseConsultaBalance($"Ha ocurrido un error con la consulta de balance. {e.Message}");
            Console.WriteLine(ResponseConsultaBalance.Mensaje);

            tblResponses.Resultado = "Fallida";
        }
        bancoEntities.tblResponses.Add(tblResponses);
    }
    */
    public class BalanceRequest : RequestHeader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BalanceRequest(int NoCuenta, int cedula)
        {
            CuentaOrigen = NoCuenta;
            Cedula = cedula;
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