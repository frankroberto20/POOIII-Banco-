using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CapaIntegracion
{
    /// <summary>
    /// Summary description for MainService
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "https://capaintegracionbanco.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        [WebMethod(MessageName = "BalanceMethod")]
        public BalanceResponse Balance(int noCuenta, string cedula)
        {
            BalanceRequest balanceRequest = new BalanceRequest(noCuenta, cedula);
            return balanceRequest.Balance();
        }

        [WebMethod(MessageName = "RetiroMethod")]
        public RetiroResponse Retiro(int noCuenta, string cedula, decimal Monto)
        {
            RetiroRequest retiroRequest = new RetiroRequest(noCuenta, cedula, Monto);
            return retiroRequest.Retiro();
        }

        [WebMethod(MessageName = "DepositoMethod")]
        public DepositoResponse Deposito(int noCuenta, string cedula, decimal Monto)
        {
            DepositoRequest depositoRequest = new DepositoRequest(noCuenta, cedula, Monto);
            return depositoRequest.Deposito();
        }

        [WebMethod(MessageName = "TransferenciaMethod")]
        public TransferenciaResponse Transferencia(int cuentaOrigen, string cedula, decimal monto, string bancoDestino, int cuentaDestino, string cedulaDestino)
        {
            TransferenciaRequest transferenciaRequest = new TransferenciaRequest(cuentaOrigen, cedula, monto, bancoDestino, cuentaDestino, cedulaDestino);
            return transferenciaRequest.Transferencia();
        }
    }
}
