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
        public TransferenciaResponse Transferencia()
        {
            
        }
    }
}
