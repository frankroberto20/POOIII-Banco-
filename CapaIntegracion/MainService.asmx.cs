using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MainServ;

namespace CapaIntegracion
{
    /// <summary>
    /// Summary description for MainService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService
    {

        [WebMethod]
        public BalanceResponse Balance(int noCuenta, int cedula)
        {
            BalanceRequest balanceRequest = new BalanceRequest(noCuenta, cedula);
            return balanceRequest.Balance();
        }

        [WebMethod]
        public RetiroResponse Retiro(int noCuenta, decimal Monto)
        {
            RetiroRequest retiroRequest = new RetiroRequest(noCuenta, Monto);
            return retiroRequest.Retiro();
        }

        [WebMethod]
        public DepositoResponse Deposito(int noCuenta, decimal Monto)
        {
            DepositoRequest depositoRequest = new DepositoRequest(noCuenta, Monto);
            return depositoRequest.Deposito();
        }

        [WebMethod]
        public TransferenciaResponse Transferencia(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            TransferenciaRequest transferenciaRequest = new TransferenciaRequest(cuentaOrigen, cedula, monto, bancoDestino, cuentaDestino, cedulaDestino);
            return transferenciaRequest.Transferencia();
        }
    }
}


/*[WebMethod]
        // Probablemente los parametros del metodo se cambiaran por un objeto que tendre que descomponer
        public TransferenciaResponse Transferencia(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino)
        {
            //si se me envia como objeto, me ahorro el crear el objeto tipo TransferenciaRequest
            TransferenciaRequest trq = new TransferenciaRequest(cuentaOrigen, cedula, monto, bancoDestino, cuentaDestino, cedulaDestino);
            //Un if para diferenciar entre si es banco local o un banco aparte
            //Preguntar a Ebank con que cuales son los bancoDestino existentes
            if (bancoDestino.ToUpper() == "LOCAL")
            {
                //(Aca ira el webMethod de core que me permite enviarle sus parametros)
                //Me envian un response
                TransferenciaResponse tr = new TransferenciaResponse();
                
                if (true)
                {
                    //si el response es afirmativo:
                    // hacer un cambio de balance en mi base de datos
                }
                return tr;

            }
            else
            {
                //Extraer del request el bancoDestino
                //if para ejecutar el webservice de ese banco
            }
 */