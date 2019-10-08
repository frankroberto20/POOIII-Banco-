using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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

        public BalanceRequest(int NoCuenta)
        {
            CuentaOrigen = NoCuenta;
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
                log.Info($"Core no disponible, utilizando base de datos local {e}");
                decimal balance = 0; //ConsultarBalance();
                DateTime date = DateTime.Now;
                log.Info($"Chequeo de balance a cuenta {CuentaOrigen} a las {date}, realizado");
                BalanceResponse balanceResponse = new BalanceResponse(DateTime.Now, 0, "Success", balance); //ConsultarBalance();
                return balanceResponse;
            }
        }
    }
}