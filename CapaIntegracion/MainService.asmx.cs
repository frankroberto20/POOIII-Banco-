using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MainServ;
using log4net;

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
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        [WebMethod]
        public DepositoResponse Deposito()
        {
            try
            {
                //(MetodoCore para descargar la base de datos)

            }
            catch (Exception ex)
            {

            }
        }
        [WebMethod]
        public RetiroResponse Retiro()
        {

        }
        [WebMethod]
        // Probablemente los parametros del metodo se cambiaran por un objeto que tendre que descomponer
        public TransferenciaResponse Transferencia(int cuentaOrigen, int cedula, decimal monto, string bancoDestino, int cuentaDestino, int cedulaDestino, DateTime date)
        {
            //si se me envia como objeto, me ahorro el crear el objeto tipo TransferenciaRequest
            TransferenciaRequest trq = new TransferenciaRequest(cuentaOrigen, cedula, monto, bancoDestino, cuentaDestino, cedulaDestino, date);
            //Un if para diferenciar entre si es banco local o un banco aparte
            //Preguntar a Ebank con que cuales son los bancoDestino existentes
            if (bancoDestino.ToUpper() == "LOCAL")
            {
                try
                {
                    //(Aca ira el webMethod de core que me permite enviarle sus parametros)
                    //Me envian un response, ese response lo convierto a nuestro propio response
                    TransferenciaResponse tr = trq.Transferencia();

                    if (true)
                    {
                        //si el response es afirmativo:
                        // hacer un cambio de balance en mi base de datos
                    }
                    return tr;

                }
                catch (Exception ex)
                {
                    Logger.Info("No conexion con core: " + ex.Message);
                    if(trq.cuentaOrigen
                    
                }
            }
            else
            {
                try
                {
                    //Extraer del request el bancoDestino
                    //if para ejecutar el webservice de ese banco

                }
                catch (Exception ex)
                {
                    Logger.Info("No conexion: " + ex.Message);
                    return (trq.Transferencia(DateTime.Now, 0, "Imposible conexion"));
                }
            }
        }
    }
}
