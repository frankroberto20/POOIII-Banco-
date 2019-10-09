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

        [WebMethod(MessageName = "BalanceMethod")]
        public BalanceResponse Balance(int noCuenta, int cedula)
        {

            BalanceRequest balanceRequest = new BalanceRequest(noCuenta, cedula);
            return balanceRequest.Balance();
        }

        [WebMethod(MessageName = "RetiroMethod")]
        public RetiroResponse Retiro(int noCuenta, decimal Monto)
        {
            RetiroRequest retiroRequest = new RetiroRequest(noCuenta, Monto);
            return retiroRequest.Retiro();
        }

        [WebMethod(MessageName = "DepositoMethod")]
        public DepositoResponse Deposito(int noCuenta, decimal Monto)
        {
            DepositoRequest depositoRequest = new DepositoRequest(noCuenta, Monto);
            return depositoRequest.Deposito();
        }

        [WebMethod(MessageName = "TransferenciaMethod")]
        public TransferenciaResponse Transferencia(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            TransferenciaRequest transferenciaRequest = new TransferenciaRequest(cuentaOrigen, cedula, monto, bancoDestino, cuentaDestino, cedulaDestino);
            return transferenciaRequest.Transferencia();
        }
    }
}
